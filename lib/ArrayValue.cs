using DSL.ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public class ArrayValue : Value
    {
        private Value[] _elements;

        public ArrayValue(int size)
        {
            _elements = new Value[size];
        }

        public ArrayValue(Value[] elements)
        {
            _elements = new Value[elements.Length];
            Array.Copy(elements, _elements, elements.Length); // Corrected Array.Copy
        }

        public ArrayValue(ArrayValue array)
        {
            if (array != null)
            {
                _elements = new Value[array._elements.Length];
                Array.Copy(array._elements, _elements, array._elements.Length);
            }
            else
            {
                _elements = new Value[0]; // Handle null input
            }
        }

        public Value Get(int index)
        {
            return _elements[index];
        }

        public void Set(int index, Value value)
        {
            _elements[index] = value;
        }

        public double AsDouble()
        {
            throw new Exception("Cannot cast array to number");
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            foreach (Value element in _elements)
            {
                sb.Append(element.ToString());
                sb.Append(" ");
            }
            sb.Append("] ");
            if (sb.Length > 0)
            {
                sb.Length--;
            }
            return sb.ToString();
        }


        public override string ToString()
        {
            return AsString();
        }

    }
}
