using DSL.lib.func.str;
using DSL.lib.func.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.Modules
{
    internal class @string : Module
    {
        public void init()
        {
            Functions.Set("upp", new UpperFunction());
            Functions.Set("low", new LowerFunction());
            Functions.Set("replace", new ReplaceFunction());
            Functions.Set("substr", new SubstrFunction());
            Functions.Set("in", new InFunction());
            Functions.Set("join", new JoinFunction());

        }
    }
}
