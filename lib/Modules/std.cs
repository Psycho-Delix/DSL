using DSL.lib.func.str;
using DSL.lib.func.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.Modules
{
    internal class std : Module
    {
        public void init()
        {
            Functions.Set("outln", new OutputLnFunction());
            Functions.Set("out", new OutputFunction());
            Functions.Set("input", new InputFunction());
            Functions.Set("len", new LenFunction());
            Functions.Set("exit", new ExitFunction());
            Functions.Set("clear", new ClearFunction());
        }
    }
}
