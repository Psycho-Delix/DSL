using DSL.lib;
using DSL.lib.func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class FunctionalExpression : Expression
    {
        string _name;
        private List<Expression> _arguments;

        public FunctionalExpression(string name)
        {
            _name = name;
            _arguments = new List<Expression>();
        }

        public FunctionalExpression(string name, List<Expression> arguments)
        {
            _name = name;
            _arguments = arguments;
        }

        public void AddArgument(Expression arg)
        {
            _arguments.Add(arg);
        }

        public Value Eval()
        {
            int size = _arguments.Count;
            Value[] values = new Value[size];
            for(int i = 0; i < size; i++)
            {
                values[i] = _arguments[i].Eval();
            }
            Function function = Functions.Get(_name);
            if (function.GetType() == typeof(UserDefineFunction))
            {
                UserDefineFunction userFunction = (UserDefineFunction)function;
                if (size != userFunction.GetArgsCount()) throw new Exception("Args count mismatch");

                Variables.Push();
                for(int i = 0; i< size; i++)
                {
                    Variables.Set(userFunction.GetArgsName(i), values[i]);
                }
                Value result = userFunction.Execute(values);
                Variables.Pop();
                return result;
            }
            return function.Execute(values);
        }

        public override string ToString()
        {
            return _name + "(" + _arguments.ToString() + ")";
        }
    }
}
