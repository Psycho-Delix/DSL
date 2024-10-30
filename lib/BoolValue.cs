using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    internal class BoolValue : Value
    {
        bool _value;

        public BoolValue(bool value)
        {
            _value = value ? true : false;
        }

        public double AsDouble()
        {
            if(_value == true)
            {
                return 1;
            }
            return 0;
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
