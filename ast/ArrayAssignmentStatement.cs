using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ArrayAssignmentStatement : Statement
    {
        public ArrayAccessExpression array;
        public Expression _expression;

        public ArrayAssignmentStatement(ArrayAccessExpression array, Expression expression)
        {
            this.array = array;
            _expression = expression;
        }

        public void execute()
        {
            array.GetArray().Set(array.LastIndex(), _expression.Eval());
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}", array.ToString(), _expression);
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }


    }
}
