using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ArrayAssigmentStatement : Statement
    {
        private ArrayAccessExpression array;
        private Expression _expression;

        public ArrayAssigmentStatement(ArrayAccessExpression array, Expression expression)
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
    }
}
