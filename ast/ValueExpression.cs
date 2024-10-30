using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ValueExpression : Expression
    {

        public Value _value;

        public ValueExpression(double value)
        {
            _value = new NumberValue(value);
        }

        public ValueExpression(string value)
        {
            _value = new StringValue(value);
        }

        public ValueExpression(bool value)
        {
            _value = new BoolValue(value);
        }

        public Value Eval()
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.AsString();
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
