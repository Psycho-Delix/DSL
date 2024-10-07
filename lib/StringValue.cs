using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    internal class StringValue : Value
    {
        string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public double AsDouble()
        {
            try
            {
                return Convert.ToDouble(_value);
            }
            catch(FormatException e)
            {
                return 0;
            }
        }

        public string AsString()
        {
            return _value;
        }

        public override string ToString()
        {
            return AsString();
        }
    }
}
