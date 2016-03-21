using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;
using ServiceSpace.Dashboard.ViewModels;
using ServiceSpace.Dashboard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceSpace.Dashboard.Windsor
{
    public class WPFWindowActivator : DefaultComponentActivator
    {
        public WPFWindowActivator(ComponentModel model, IKernelInternal kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
            : base(model, kernel, onCreation, onDestruction)
        {

        }

        protected override object CreateInstance(CreationContext context, ConstructorCandidate constructor, object[] arguments)
        {
            var component = base.CreateInstance(context, constructor, arguments);
            AssignViewModel(component, arguments);
            return component;
        }

        private void AssignViewModel(object component, object[] arguments)
        {
            var frameworkElement = component as FrameworkElement;
            if (frameworkElement == null || arguments == null)
            {
                return;
            }

            var vm = arguments.Where(a => a is IViewModel).FirstOrDefault();
            if (vm != null)
            {
                frameworkElement.DataContext = vm;
                AssignParentView(frameworkElement, vm);
            }
        }

        private void AssignParentView(FrameworkElement frameworkElement, object dataContext)
        {
            var view = frameworkElement as IView;
            if (view == null)
            {
                return;
            }

            var viewProp = dataContext.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && typeof(IView).IsAssignableFrom(p.PropertyType))
                .FirstOrDefault();
            if (viewProp != null)
            {
                viewProp.SetValue(dataContext, frameworkElement, null);
            }
        }
    }
}
