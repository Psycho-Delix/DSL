using DSL.lib.func.math;
using DSL.lib.func.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.Modules
{
    internal class math : Module
    {
        public void init()
        {
            Functions.Set("sin", new SinusFunction());
            Functions.Set("cos", new CosinusFunction());
            Functions.Set("abs", new AbsFunction());
            Functions.Set("sqrt", new SqrtFunction());
            Functions.Set("log", new LogFunction());
            Functions.Set("pow", new PowFunction());
            Functions.Set("max", new MaxFunction());
            Functions.Set("min", new MinFunction());
            Functions.Set("random", new RandomFunction());
            Functions.Set("gcd", new GcdFunction());
            Functions.Set("lcm", new LcmFunction());

        }
    }
}
