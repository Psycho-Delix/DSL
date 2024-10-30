using DSL.ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSL.lib
{
    public class environment
    {
        private Dictionary<string, EnumStatement> _enums = new Dictionary<string, EnumStatement>();
        private static environment _current;

        public static environment Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new environment();
                }
                return _current;
            }
        }

        public void AddEnum(EnumStatement enumStatement)
        {
            _enums[enumStatement._name] = enumStatement;
        }

        public EnumStatement GetEnum(string name)
        {
            if (_enums.ContainsKey(name))
            {
                return _enums[name];
            }
            throw new Exception($"Variable '{name}' not found in the environment.");
        }

        public bool ContainsKey(string name)
        {
            return _enums.ContainsKey(name);
        }
    }
}
