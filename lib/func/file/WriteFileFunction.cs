using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.file
{
    internal class WriteFileFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 2) throw new Exception("Two arg expected");

            string path_file = args[0].ToString();
            if (!File.Exists(path_file))
            {
                File.Create(path_file);
            }

            using (StreamWriter writer = new StreamWriter(path_file))
            {
                writer.WriteLine(args[1]);
            }

            return new NumberValue(0);
        }
    }
}
