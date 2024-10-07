using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public class CosinusFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new NumberValue(Math.Cos(args[0].AsDouble()));
        }
    }
}
