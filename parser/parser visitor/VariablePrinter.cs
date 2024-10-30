using DSL.ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.parser_visitor
{
    public class VariablePrinter : AbstractVisitor
    {
        public void visit(AssignmentStatement s)
        {
            s._expression.Accept(this);
            Console.WriteLine(s._variable.ToString());
        }

        public void visit(VariableExpression s)
        {
            Console.WriteLine(s._name.ToString());

        }
    }
}
