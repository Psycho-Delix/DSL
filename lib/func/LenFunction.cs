using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public class LenFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");

            string str = Convert.ToString(args[0].AsDouble());
            int count = str.Count();

            return new NumberValue(count);
        }
    }
}
