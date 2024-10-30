using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.system
{
    internal class CompatFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 2) throw new Exception("One arg expected");
            if (args[0].GetType() == args[1].GetType())
            {
                return new BoolValue(true);
            }
            return new BoolValue(false);
        }
    }
}
