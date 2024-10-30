using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.array
{
    public class ArrayFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            return CreateArray(args, 0);
        }

        private ArrayValue CreateArray(Value[] args, int index)
        {
            int size = (int)args[index].AsDouble();
            int last = args.Length - 1;
            ArrayValue array = new ArrayValue(size);
            if(index == last)
            {
                for(int i = 0; i < size; i++)
                {
                    array.Set(i, NumberValue.ZERO);
                }
            }
            else if(index <= last)
            {
                for (int i = 0; i < size; i++)
                {
                    array.Set(i, CreateArray(args, index + 1));
                }
            }
            return array;
        }
    }
}
