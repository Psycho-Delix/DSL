using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public interface Node
    {
        void Accept(Visitor visitor);
    }
}
