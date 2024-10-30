using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.file
{
    internal class ReadFileFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");

            string path_file = args[0].ToString();

            if (!File.Exists(path_file)) throw new Exception($"No file {path_file}");

            byte[] b;
            string data;

            byte[] content = File.ReadAllBytes(path_file);
            for (int i = 1; i < 512 && i < content.Length; i++)
            {
                if (content[i] == 0x00 && content[i - 1] == 0x00)
                {
                    b = File.ReadAllBytes(path_file);
                    data = Encoding.ASCII.GetString(b);
                    return new StringValue(data);
                }
            }

            data = File.ReadAllText(path_file);
            return new StringValue(data);
        }
    }
}
