using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ForStatement : Statement
    {
        private Statement _initialization;
        private Expression _termination;
        private Statement _increment;
        private Statement _statement;

        public ForStatement(Statement initialization, Expression termination, Statement increment, Statement block)
        {
            _initialization = initialization;
            _termination = termination;
            _increment = increment;
            _statement = block;
        }

        public void execute()
        {
            for(_initialization.execute(); _termination.Eval().AsDouble() != 0; _increment.execute())
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
            return "for " + _initialization + ", " + _termination + ", " + _increment + " " + _statement;
        }
    }
}
