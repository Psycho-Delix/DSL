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
        public string _variable;
        public Expression _expression;

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
            return string.Format("{0} = {1}", _variable, _expression);
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }

    }
}
