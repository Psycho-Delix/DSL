using DSL.lib.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class UseStatement : Statement
    {
        private static string PACAGE = "DSL.lib.Modules.";
        public Expression _expression;

        public UseStatement(Expression expression)
        {
            _expression = expression;
        }

        public void execute()
        {
            try
            {
                string moduleName = _expression.Eval().AsString();
                Type moduleType = Type.GetType("DSL.lib.Modules." + moduleName);
                if (moduleType != null)
                {
                    Module module = (Module)Activator.CreateInstance(moduleType);
                    module.init();
                }
                else
                {
                    Console.WriteLine($"module  {moduleName} not found\r\n.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting the module: {ex.Message}");
            }
        }

        public override string ToString()
        {
            return "use " + _expression;
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
