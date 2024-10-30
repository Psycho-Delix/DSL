using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.math
{
    public class PowFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 2) throw new Exception("Two arg expected");
            return new NumberValue(Math.Pow(args[0].AsDouble(), args[1].AsDouble()));
        }
    }
}
