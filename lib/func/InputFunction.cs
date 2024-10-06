using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    using System;

    public class InputFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length == 0)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return new NumberValue(result); 
                }
                else
                {
                    return new StringValue(input);
                }
            }

            throw new Exception("Too many arguments");
        }
    }

}
