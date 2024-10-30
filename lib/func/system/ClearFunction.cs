using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.system
{
    public class ClearFunction : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value Execute(params Value[] args)
        {
            Console.Clear();
            return ZERO;
        }
    }
}
