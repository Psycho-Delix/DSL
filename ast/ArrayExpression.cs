using DSL.lib.func;
using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ArrayExpression : Expression
    {
        public List<Expression> _elements = new List<Expression>();

        public ArrayExpression(List<Expression> arguments)
        {
            _elements = arguments;
        }

        public Value Eval()
        {
            int size = _elements.Count;
            ArrayValue array = new ArrayValue(size);
            for (int i = 0; i < size; i++)
            {
                array.Set(i, _elements[i].Eval());
            }
            return array;
        }

        public override string ToString()
        {
            return _elements.ToString();
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }

    }
}
