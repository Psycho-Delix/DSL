using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class DoWhileStatement : Statement
    {
        public Expression _condition;
        public Statement _statement;

        public DoWhileStatement(Expression condition, Statement statement)
        {
            _condition = condition;
            _statement = statement;
        }

        public void execute()
        {
            do
            {
                try
                {
                    _statement.execute();
                }
                catch (BreakStatement bs)
                {
                    break;
                }
                catch (ContinueStatement cs)
                {
                    //continue;
                }
            }
            while (_condition.Eval().AsDouble() != 0);
        }

        public override string ToString()
        {
            return "do " + _statement + " while " + _condition;
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
