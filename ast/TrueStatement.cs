using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class TrueStatement : Statement
    {
        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public void execute()
        {
            
        }
    }
}
