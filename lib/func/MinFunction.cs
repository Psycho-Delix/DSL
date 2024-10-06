using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func
{
    public class MinFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length < 1) throw new Exception("min one arg expected");
            double min = 999999999999;
            foreach (var arg in args)
            {
                if (arg.AsDouble() < min)
                {
                    min = arg.AsDouble();
                }
            }
            return new NumberValue(min);
        }
    }
}
