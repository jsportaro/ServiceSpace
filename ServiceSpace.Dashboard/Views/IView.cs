using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Dashboard.Views
{
    public interface IView
    {
    }

public class ExampleClass
{
    private int _counter;

    public void Increment()
    {
        var _incrementAmount = 1;

        _counter += _incrementAmount;
    }
}
}
