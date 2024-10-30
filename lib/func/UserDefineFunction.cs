using DSL.ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func
{
    public class UserDefineFunction : Function
    {
        private List<string> _argName;
        private Statement _body;

        public UserDefineFunction(List<string> argName, Statement body)
        {
            _argName = argName;
            _body = body;
        }

        public int GetArgsCount()
        {
            return _argName.Count;
        }

        public string GetArgsName(int index)
        {
            if (index < 0 || index >= _argName.Count) return "";
            return _argName[index];
        }

        public Value Execute(params Value[] args)
        {
            try
            {
                _body.execute();
                return new NumberValue(0);
            }
            catch (ReturnStatement rt)
            {
                return rt.GetResult();
            }
        }
    }
}
