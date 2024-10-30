using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.array
{
    public class AddArrayFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if(args.Length != 2) throw new Exception("Two arg expected");
            if (args[0].GetType() == typeof(ArrayValue))
            {
                ArrayValue arr = (ArrayValue)args[0];
                arr.Add(args[1]);
                return new NumberValue(0);
            }
            else throw new Exception("Not Array");
        }
    }
}
