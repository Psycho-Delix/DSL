using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public class ExitFunction : Function
    {
        private static NumberValue ZERO = new NumberValue(0);

        public Value Execute(params Value[] args)
        {
            if (args.Length != 0) throw new Exception("Zero arg expected");
            else Environment.Exit(0);
            return ZERO;
        }
    }
}
