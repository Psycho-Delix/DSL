using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ConditionalExpression : Expression
    {
        public enum Operator
        {
            PLUS,
            MINUS,
            MULTIPLY,
            DEVIDE,

            EQUALS,
            NOT_EQUALS,

            LT,
            LTEQ,
            GT,
            GTEQ,

            AND,
            OR
        };

        public Operator _operation;
        public Expression _expr1, _expr2;

        public ConditionalExpression(Operator operation, Expression expr1, Expression expr2)
        {
            _operation = operation;
            _expr1 = expr1;
            _expr2 = expr2;
        }

        public Value Eval()
        {
            Value value1 = _expr1.Eval();
            Value value2 = _expr2.Eval();

            double number1, number2;
            if(value1.GetType() == typeof(StringValue))
            {
                number1 = value1.AsString().CompareTo(value2.AsString());
                number2 = 0;
            }
            else
            {
                number1 = value1.AsDouble();
                number2 = value2.AsDouble();
            }

            bool result;
            switch (_operation)
            {
                case Operator.LT: result = number1 < number2; break;
                case Operator.LTEQ: result = number1 <= number2; break;
                case Operator.GT: result = number1 > number2; break;
                case Operator.GTEQ: result = number1 >= number2; break;
                case Operator.NOT_EQUALS: result = number1 != number2; break;
                case Operator.AND: result = (number1 != 0) && (number2 != 0); break;
                case Operator.OR: result = (number1 != 0) || (number2 != 0); break;
                case Operator.EQUALS:
                default:
                    result = number1 == number2; break;
            }
            return new NumberValue(result);
        }

        public override string ToString()
        {
            return String.Format("({0} {1} {2})", _expr1, _operation, _expr2);
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
