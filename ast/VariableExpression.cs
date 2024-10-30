using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class VariableExpression : Expression
    {
        public string _name;

        public VariableExpression(string name)
        {
            _name = name;
        }

        public Value Eval()
        {
            if (!Variables.IsExists(_name)) throw new Exception("Constant does not exists: " + _name);
            return Variables.Get(_name);
        }

        public override string ToString()
        {
            return _name;
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
