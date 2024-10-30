using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.system
{
    internal class IsPrimaryFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            if (args[0].AsDouble() <= 1)
            {
                return new BoolValue(false);
            }
            if (args[0].AsDouble() <= 3)
            {
                return new BoolValue(true);
            }
            if (args[0].AsDouble() % 2 == 0 || args[0].AsDouble() % 3 == 0)
            {
                return new BoolValue(false);
            }
            for (int i = 5; i * i <= args[0].AsDouble(); i += 6)
            {
                if (args[0].AsDouble() % i == 0 || args[0].AsDouble() % (i + 2) == 0)
                {
                    return new BoolValue(false);
                }
            }
            return new BoolValue(true);
        }
    }
}
