using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ForStatement : Statement
    {
        public Statement Initialization { get; }
        public Expression Termination { get; }
        public Statement Increment { get; }
        public Statement Statement { get; }

        public ForStatement(Statement initialization, Expression termination, Statement increment, Statement statement)
        {
            Initialization = initialization;
            Termination = termination;
            Increment = increment;
            Statement = statement;
        }

        public void execute()
        {
            Initialization.execute();
            while (Termination.Eval().AsDouble() != 0)
            {
                try
                {
                    Statement.execute();
                }
                catch (BreakStatement bs)
                {
                    break;
                }
                catch (ContinueStatement cs)
                {
                    // continue;
                }
                Increment.execute();
            }
        }

        public override string ToString()
        {
            return "for " + Initialization + ", " + Termination + ", " + Increment + " " + Statement;
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
