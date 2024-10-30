using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.math
{
    internal class GcdFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 2) throw new Exception("Two arg expected");
            double a = args[0].AsDouble();
            double b = args[1].AsDouble();
            while (b != 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return new NumberValue(a);
        }
    }
}
