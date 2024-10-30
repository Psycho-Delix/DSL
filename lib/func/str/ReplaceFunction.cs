using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.str
{
    public class ReplaceFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 3) throw new Exception("thre arg expected");
            return new StringValue(args[0].ToString().Replace(args[1].ToString(), args[2].ToString()));
        }
    }
}
