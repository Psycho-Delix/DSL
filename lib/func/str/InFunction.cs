using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.str
{
    internal class InFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 2) throw new Exception("Two arg expected");
            if (args[0].GetType() != typeof(StringValue) || args[1].GetType() != typeof(StringValue)) throw new Exception($"{args[0]} no string");

            string text = args[0].ToString();
            string substring = args[1].ToString();

            List<int> indices = new List<int>();
            int index = text.IndexOf(substring);
            while (index >= 0) // Изменяем условие цикла на index >= 0
            {
                indices.Add(index);
                index = text.IndexOf(substring, index + substring.Length);
            }

            return new ArrayValue(indices.Select(i => new NumberValue(i)).ToArray());
        }
    }


}
