using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.str
{
    internal class JoinFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length < 2) throw new Exception("Min two arg expected");
            string word = "";
            if (args[1].GetType() == typeof(ArrayValue))
            {
                string[] words = args[1].ToString().Split(' ');
                word = string.Join(args[0].ToString(), words);
            }
            else
            {
                string[] words = new string[args.Length - 1];
                for (int i = 1; i <= words.Length; i++)
                {
                    words[i - 1] = args[i].ToString();
                }
                word = string.Join(args[0].ToString(), words);
            }
            return new StringValue(word);
        }
    }
}
