using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class BinaryExpression : Expression
    {
        public char _operation;
        public Expression _expr1, _expr2;

        public BinaryExpression(char operation, Expression expr1, Expression expr2)
        {
            _operation = operation;
            _expr1 = expr1;
            _expr2 = expr2;
        }

        public Value Eval()
        {
            Value value1 = _expr1.Eval();
            Value value2 = _expr2.Eval();
            if((value1.GetType() == typeof(StringValue)) || (value1.GetType() == typeof(ArrayValue)))
            {
                string string1 = value1.AsString();
                string string2 = value2.AsString();
                switch (_operation)
                {
                    case '*':
                        int iterator = (int)value2.AsDouble();
                        StringBuilder buffer = new StringBuilder();
                        for(int i = 0; i<iterator; i++)
                        {
                            buffer.Append(string1);
                        }
                        return new StringValue(buffer.ToString());
                    case '+':
                    default:
                        return new StringValue(string1 + string2);
                }
            }

            double number1 = value1.AsDouble();
            double number2 = value2.AsDouble();
            switch (_operation)
            {
                case '-': return new NumberValue(number1 - number2);
                case '*': return new NumberValue(number1 * number2);
                case '/': return new NumberValue(number1 / number2);
                case '+':
                default:
                    return new NumberValue(number1 + number2);
            }
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
