using DSL.ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func
{
    public class SizeArrayFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if(args.Length != 1) throw new Exception("One arg expected");
            if (args[0].GetType() == typeof(ArrayValue))
            {
                ArrayValue Arr = (ArrayValue)args[0];
                return new NumberValue(Arr.GetSize());
            }
            else throw new Exception("Not Array");
        }
    }
}
