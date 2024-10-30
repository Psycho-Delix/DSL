using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public class Variables
    {
        private static NumberValue ZERO = new NumberValue(0);
        private static Dictionary<string, Value> _variables = new Dictionary<string, Value>()
        {
            {"PI", new NumberValue(Math.PI)},
            {"E", new NumberValue(Math.E)},
            {"HUY", new NumberValue(18.5)},
            {"NULL", new NumberValue(0)},
        };
        private static Stack<Dictionary<string, Value>> _stack = new Stack<Dictionary<string, Value>>();

        public static void Push()
        {
            _stack.Push(new Dictionary<string, Value>(_variables));
        }

        public static void Pop()
        {
            _variables = _stack.Pop();
        }

        public static bool IsExists(string key)
        {
            return _variables.ContainsKey(key);
        }

        public static Value Get(string key)
        {
            if (!IsExists(key)) return ZERO;
            return _variables[key];
        }

        public static void Set(string name, Value value)
        {
            _variables[name] = value;
        }

        // Добавьте метод Remove
        public static void Remove(string key)
        {
            if (_variables.ContainsKey(key))
            {
                _variables.Remove(key);
            }
        }
    }
}
