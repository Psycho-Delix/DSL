using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.system
{
    internal class IsStringFunctin : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            if (args[0].GetType() == typeof(StringValue))
            {
                return new BoolValue(true);
            }
            return new BoolValue(false);
        }
    }
}
