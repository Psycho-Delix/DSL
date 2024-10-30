using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.array
{
    public class CopyFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            if (args[0].GetType() == typeof(ArrayValue))
            {
                ArrayValue array = (ArrayValue) args[0];
                return new ArrayValue(array);
            }
            else throw new Exception("Not Array");
        }
    }
}
