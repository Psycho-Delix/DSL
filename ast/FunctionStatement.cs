using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class FunctionStatement : Statement
    {
        public FunctionalExpression _function;

        public FunctionStatement(FunctionalExpression function)
        {
            _function = function;
        }

        public void execute()
        {
            _function.Eval();
        }

        public override string ToString()
        {
            return _function.ToString();
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
