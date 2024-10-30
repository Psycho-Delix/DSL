using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.array
{
    internal class RemoveFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length > 2 || args.Length < 1) throw new Exception("min one arg expected");
            if(args.Length == 2)
            {
                if (args[0].GetType() == typeof(ArrayValue))
                {
                    ArrayValue array = (ArrayValue)args[0];
                    array.Remove((int)args[1].AsDouble());
                    return new NumberValue(0);
                }
                else throw new Exception("Not Array");
            }
            if (args.Length == 1)
            {
                if (args[0].GetType() == typeof(ArrayValue))
                {
                    ArrayValue array = (ArrayValue)args[0];
                    array.Remove(array.GetSize() - 1);
                    return new NumberValue(0);
                }
                else throw new Exception("Not Array");
            }
            else return new NumberValue(0);
        }
    }
}
