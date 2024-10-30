using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.array
{
    internal class SortArrayFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");

            if (args[0] is ArrayValue arrValue)
            {
                var arr = arrValue.GetElements(); 

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (Compare(arr[j], arr[j + 1]) > 0)
                        {
                            var temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }

                return new ArrayValue(arr);
            }
            else
            {
                throw new Exception("Not Array");
            }
        }

        private int Compare(Value a, Value b)
        {
            if (a is NumberValue numA && b is NumberValue numB)
            {
                return numA.AsDouble().CompareTo(numB.AsDouble()); 
            }

            throw new Exception("Incomparable values");
        }
    }
}
