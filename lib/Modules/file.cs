using DSL.lib.func.file;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.Modules
{
    internal class file : Module
    {
        public void init()
        {
            Functions.Set("write", new WriteFileFunction());
            Functions.Set("read", new ReadFileFunction());
            Functions.Set("exists", new ExistsFileFunction());
        }
    }
}
