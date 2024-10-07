using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func
{
    public class ConvertToNumFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if(args.Length != 1) throw new Exception("One arg expected");
            return new NumberValue(args[0].AsDouble());
        }
    }
}
