using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public class NumberValue : Value
    {
        double _value;
        public static NumberValue ZERO = new NumberValue(0);

        public NumberValue(bool value)
        {
            _value = value ? 1 : 0;
        }

        public NumberValue(double value)
        {
            _value = value;
        }

        public double AsDouble()
        {
            return _value;
        }

        public string AsString()
        {
            return Convert.ToString(_value);
        }

        public override string ToString()
        {
            return AsString();
        }
    }
}
