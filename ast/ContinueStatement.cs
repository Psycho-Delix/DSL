using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class ContinueStatement : Exception, Statement
    {
        public void execute()
        {
            throw this;
        }

        public override string ToString()
        {
            return "continue";
        }
    }
}
