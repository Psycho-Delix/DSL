using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.system
{
    public class RandomFunction : Function
    {
        private Random _random = new Random();

        public Value Execute(params Value[] args)
        {
            if (args.Length != 2) throw new Exception("Two arguments expected");

            double start = args[0].AsDouble();
            double end = args[1].AsDouble();

            double random = _random.NextDouble() * (end - start) + start;
            random = Convert.ToInt32(random);
            return new NumberValue(random);
        }
    }
}
