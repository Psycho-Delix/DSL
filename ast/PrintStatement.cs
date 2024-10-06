using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class PrintStatement : Statement
    {
        private Expression _expression;

        public PrintStatement(Expression expression)
        {
            _expression = expression;
        }

        public void execute()
        {
            Console.Write(_expression.Eval());
        }

        public override string ToString()
        {
            return "print " + _expression;
        }
    }
}
