using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.file
{
    internal class ExistsFileFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");

            string path_file = args[0].ToString();
            if (File.Exists(path_file)) return new BoolValue(true);
            return new BoolValue(false);
        }
    }
}
