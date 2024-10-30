using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.system
{
    internal class IsEvalFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            if (args[0].GetType() == typeof(NumberValue))
            {
                if (args[0].AsDouble() % 2 == 0)
                {
                    return new BoolValue(true);
                }
                return new BoolValue(false);
            }
            return new BoolValue(false);
        }
    }
}
