using DSL.lib.func.array;
using DSL.lib.func.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.Modules
{
    internal class array : Module
    {
        public void init()
        {
            Functions.Set("newarray", new ArrayFunction());
            Functions.Set("size", new SizeArrayFunction());
            Functions.Set("add", new AddArrayFunction());
            Functions.Set("remove", new RemoveFunction());
            Functions.Set("average", new AverageFunction());
            Functions.Set("sum", new SumFunction());
            Functions.Set("maxEl", new MaxElementFunction());
            Functions.Set("minEl", new MinElementFunction());
            Functions.Set("sort", new SortArrayFunction());

        }
    }
}
