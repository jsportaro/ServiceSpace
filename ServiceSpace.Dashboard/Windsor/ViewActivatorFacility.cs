using Castle.MicroKernel.Facilities;
using ServiceSpace.Dashboard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Dashboard.Windsor
{
    public class ViewActivatorFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
        }

        void Kernel_ComponentModelCreated(Castle.Core.ComponentModel model)
        {
            var isView = model.Services.Any(s => typeof(IView).IsAssignableFrom(s));

            if (!isView) return;

            if (model.CustomComponentActivator == null)
                model.CustomComponentActivator = typeof(WPFWindowActivator);
        }
    }
}
