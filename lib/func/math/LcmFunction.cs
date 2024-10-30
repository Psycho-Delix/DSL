using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.math
{
    internal class LcmFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 2) throw new Exception("Two arg expected");
            double a = args[0].AsDouble();
            double b = args[1].AsDouble();
            double max = Math.Max(a, b);
            for(double i = max; ;i+=max)
            {
                if(i%a == 0 && i%b == 0)
                {
                    return new NumberValue(i);
                }
            }
        }
    }
}
