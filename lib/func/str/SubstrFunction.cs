using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.str
{
    public class SubstrFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 3) throw new Exception("Three arguments expected.");

            if (args[1].AsDouble() < 0 ||
            args[2].AsDouble() > args[0].ToString().Length)
            {
                throw new Exception("Incorrect values for the beginning and end of the substring.");
            }
            if (args[1].AsDouble() == args[2].AsDouble())
            {
                string symbol = args[0].ToString();
                return new StringValue(Convert.ToString(symbol[symbol.Length - 1]));
            }

            int start = Convert.ToInt32(args[1].AsDouble());
            int end = Convert.ToInt32(args[2].AsDouble());

            return new StringValue(args[0].ToString().Substring(start, end - start));
        }
    }
}
