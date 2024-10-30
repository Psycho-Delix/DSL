using DSL.lib;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ReturnStatement : Exception, Statement
    {
        public Expression _expression;
        public Value _result;

        public ReturnStatement(Expression expression)
        {
            _expression = expression;
        }

        public Value GetResult()
        {
            return _result;
        }

        public void execute()
        {
            _result = _expression.Eval();
            throw this;
        }

        public override string ToString()
        {
            return "rerturn";
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
