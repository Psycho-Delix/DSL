using DSL.ast;
using DSL.lib.func;
using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace DSL.parser_visitor
{
    internal class FunctionAdder : AbstractVisitor
    {
        
        public void visit(FunctionDefineStatement s)
        {
            s._body.Accept(this);
            s.execute();
        }
    }
}