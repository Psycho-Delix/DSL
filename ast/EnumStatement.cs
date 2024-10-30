using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSL.ast
{
    public class EnumStatement : Statement
    {
        public string _name { get; private set; }
        public Dictionary<string, Value> _values { get; private set; }

        public EnumStatement(string name, List<string> values)
        {
            _name = name;
            _values = new Dictionary<string, Value>();
            for (int i = 0; i < values.Count; i++)
            {
                _values[values[i]] = new NumberValue(i); 
            }
        }

        public EnumStatement()
        {
        }

        public void Accept(Visitor visitor)
        {
            
        }

        public void execute()
        {
            
        }

        public Value GetValue(string valueName)
        {
            if (_values.ContainsKey(valueName))
            {
                return _values[valueName]; // Получаем значение из словаря
            }
            throw new Exception($"Value '{valueName}' not found in enum '{_name}'");
        }

        public void SetValue(string valueName, Value value)
        {
            if (_values.ContainsKey(valueName))
            {
                _values[valueName] = value; // Изменяем значение в словаре
                return;
            }

            throw new Exception($"Value '{valueName}' not found in enum '{_name}'");
        }
    }
}
