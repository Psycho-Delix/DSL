using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.array
{
    public class ReverseFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            if (args[0].GetType() == typeof(ArrayValue))
            {
                ArrayValue array = (ArrayValue)args[0];

                Array.Reverse(array.GetElements());

                return new ArrayValue(array.GetElements().ToArray());
            }
            else throw new Exception("Not Array");
        }
    }
}
