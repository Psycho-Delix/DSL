using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class UnaryExpression : Expression
    {
        public char _operation;
        public Expression _expr1;

        public UnaryExpression(char operation, Expression expr1)
        {
            _operation = operation;
            _expr1 = expr1;
        }

        public Value Eval()
        {
            switch( _operation )
            {
                case '-': return new NumberValue(-_expr1.Eval().AsDouble());
                case '+':
                default:
                    return _expr1.Eval();
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", _operation, _expr1);
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
