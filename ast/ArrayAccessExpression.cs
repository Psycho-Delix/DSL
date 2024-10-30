using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ArrayAccessExpression : Expression
    {
        public string _variable;
        public List<Expression> _indices;

        public ArrayAccessExpression(string variable, List<Expression> indices)
        {
            _variable = variable;
            _indices = indices;
        }

        public Value Eval()
        {
            return GetArray().Get(LastIndex());
        }

        public ArrayValue GetArray()
        {
            ArrayValue array = ConsumeArray(Variables.Get(_variable));
            int last = _indices.Count - 1;
            for (int i = 0; i < last; i++)
            {
                array = ConsumeArray(array.Get(Index(i)));
            }
            return array;
        }

        public int LastIndex()
        {
            return Index(_indices.Count() - 1);
        }

        private int Index(int index)
        {
            return (int)_indices[index].Eval().AsDouble();
        }

        private ArrayValue ConsumeArray(Value value)
        {
            if (value.GetType() == typeof(ArrayValue))
            {
                return (ArrayValue)value;
            }
            else
            {
                throw new Exception("Array axpected");
            }
        }

        public override string ToString()
        {
            return _variable + _indices;
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
