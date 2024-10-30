using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class EnumAssignmentStatement : Statement
    {
        public string _variable;
        public Expression _enumValue;

        public EnumAssignmentStatement(string variable, Expression enumValue)
        {
            _variable = variable;
            _enumValue = enumValue;
        }

        public void execute()
        {
            Value result = _enumValue.Eval();
            Variables.Set(_variable, result); // Используйте Variables для хранения значения энума
        }

        public override string ToString()
        {
            return string.Format("{0} = {1}", _variable, _enumValue);
        }

        public void Accept(Visitor visitor)
        {

        }
    }
}
