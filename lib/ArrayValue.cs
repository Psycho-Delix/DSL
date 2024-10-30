using DSL.ast;
using System;
using System.CodeDom;
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

        public void Add(Value value)
        {
            Value[] newElements = new Value[_elements.Length + 1];
            Array.Copy(_elements, newElements, _elements.Length);
            newElements[_elements.Length] = value;
            _elements = newElements;
        }

        public void Remove(int index)
        {
            Value[] newArray = new Value[_elements.Length - 1];
            int j = 0;
            for(int i = 0; i < _elements.Length; i++)
            {
                if (i != index)
                {
                    newArray[j++] = _elements[i];
                }
            }
            _elements = newArray;
        }

        public int GetSize()
        {
            return _elements.Length;
        }

        public Value[] GetElements()
        {
            return _elements;
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
            sb.Append("[");
            int len = _elements.Length; 
            for (int i = 0; i < _elements.Length; i++) 
            {
                sb.Append(_elements[i].ToString());
                if (i < len - 1) 
                {
                    sb.Append(", ");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        public override string ToString()
        {
            return AsString();
        }
    }
}
