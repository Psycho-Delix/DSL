using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class WhileStatement : Statement
    {
        public Expression _condition;
        public Statement _statement;

        public WhileStatement(Expression condition, Statement statement)
        {
            _condition = condition;
            _statement = statement;
        }

        public void execute()
        {
            while(_condition.Eval().AsDouble() != 0)
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
        }

        public override string ToString()
        {
            return "while " + _condition + " " + _statement;
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
