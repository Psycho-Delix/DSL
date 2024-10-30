using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class EnumFieldAccessExpression : Expression
    {
        public string _enumName { get; private set; }
        public string _fieldName { get; private set; }

        public EnumFieldAccessExpression(string enumName, string fieldName)
        {
            _enumName = enumName;
            _fieldName = fieldName;
        }

        public void Accept(Visitor visitor)
        {
            
        }

        public Value Eval()
        {
            environment env = environment.Current;
            EnumStatement enumStatement = env.GetEnum(_enumName);
            if (enumStatement == null)
            {
                throw new Exception($"Enum '{_enumName}' not found");
            }
            Value value = enumStatement.GetValue(_fieldName);
            return value;
        }

        public override string ToString()
        {
            return _enumName + ":" + _fieldName;
        }
    }
}
