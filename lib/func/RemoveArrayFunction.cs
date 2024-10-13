using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func
{
    public class RemoveArrayFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("ожидался один аргумент!!!");
            if (args[0].GetType() == typeof(ArrayValue))
            {
                ArrayValue arr = (ArrayValue)args[0];

                if (arr.GetSize() == 0) 
                    throw new Exception("Пустой массив!!!");

                Value removedValue = arr.Get(arr.GetSize() - 1);
                arr.Remove(arr.GetSize() - 1);
                return removedValue;
            }
            else throw new Exception("Не массив!!!");
        }
    }
}
