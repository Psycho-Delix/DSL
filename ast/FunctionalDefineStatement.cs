using DSL.lib;
using DSL.lib.func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class FunctionalDefineStatement : Statement
    {
        private string _name;
        private List<string> _argName;
        private Statement _body;

        public FunctionalDefineStatement(string name, List<string> argName, Statement body)
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
    }
}
