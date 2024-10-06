using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class IfStatement : Statement
    {
        private Expression _expression;
        private Statement _ifStatement, _elseStatement;

        public IfStatement(Expression expression, Statement ifstatement, Statement elseStatement)
        {
            _expression = expression;
            _ifStatement = ifstatement;
            _elseStatement = elseStatement;
        }

        public void execute()
        {
            double result = _expression.Eval().AsDouble();
            if (result != 0)
            {
                _ifStatement.execute();
            }
            else if (_elseStatement != null)
            {
                _elseStatement.execute();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("if ").Append(_expression).Append(" ").Append(_ifStatement);
            if ( _elseStatement != null )
            {
                result.Append("\nelse ").Append(_elseStatement);
            }
            return result.ToString();
        }
    }
}
