using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.array
{
    internal class MaxElementFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            if (args[0].GetType() != typeof(ArrayValue)) throw new Exception("No array");
            ArrayValue array = (ArrayValue)args[0];
            Value[] values = array.GetElements();
            double[] arr = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                arr[i] = values[i].AsDouble();
            }

            double max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return new NumberValue(max);
        }
    }
}
