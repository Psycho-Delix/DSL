using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    internal class AndExpression : Expression
    {
        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public Value Eval()
        {
            throw new NotImplementedException();
        }

    }
}
