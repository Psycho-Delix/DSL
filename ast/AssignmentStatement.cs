using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSL.ast
{
    public class AssignmentStatement : Statement
    {
        private string _variable;
        private Expression _expression;

        public AssignmentStatement(string variable, Expression expression)
        {
            _variable = variable;
            _expression = expression;
        }

        public void execute()
        {
            Value result = _expression.Eval();
            Variables.Set(_variable, result);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}", _variable, _expression);
        }
    }
}
