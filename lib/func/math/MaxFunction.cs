using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.math
{
    public class MaxFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length < 1) throw new Exception("min one arg expected");
            double max = 0;
            foreach (var arg in args)
            {
                if (arg.AsDouble() > max)
                {
                    max = arg.AsDouble();
                }
            }
            return new NumberValue(max);
        }
    }
}
