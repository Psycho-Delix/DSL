using DSL.lib.func.array;
using DSL.lib.func.file;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.Modules
{
    internal class algorithm : Module
    {
        public void init()
        {
            Functions.Set("copy", new CopyFunction());
            Functions.Set("reverse", new ReverseFunction());
        }
    }
}
