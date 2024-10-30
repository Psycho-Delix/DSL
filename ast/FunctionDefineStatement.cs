using DSL.lib;
using DSL.lib.func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class FunctionDefineStatement : Statement
    {
        public string _name;
        public List<string> _argName;
        public Statement _body;

        public FunctionDefineStatement(string name, List<string> argName, Statement body)
        {
            _name = name;
            _argName = argName;
            _body = body;
        }

        public void execute()
        {
            Functions.Set(_name, new UserDefineFunction(_argName, _body));
        }

        public override string ToString()
        {
            return "def (" + _argName.ToString() + ") " + _body.ToString();
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
