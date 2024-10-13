using DSL.lib.func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public class Functions
    {
        private static readonly Dictionary<string, Function> _functions = new Dictionary<string, Function>()
        {
            {"sin", new SinusFunction() },
            {"cos", new CosinusFunction() },
            {"len", new LenFunction() },
            {"max", new MaxFunction() },
            {"min", new MinFunction() },
            {"out", new OutputFunction() },
            {"input", new InputFunction() },
            {"random", new RandomFunction() },
            {"exit", new ExitFunction() },
            {"clear", new ClearFunction() },
            {"newarray", new ArrayFunction() },
            {"num", new ConvertToNumFunction() },
            {"str", new ConvertToStringFunction() },
            {"size", new SizeArrayFunction() },
            {"add", new AddArrayFunction() }
            {"remove", new RemoveArrayFunction() }
        };

        public static bool IsExists(string key)
        {
            return _functions.ContainsKey(key);
        }

        public static Function Get(string key)
        {
            if (!IsExists(key)) throw new Exception("Unknow function " + key);
            return _functions[key];
        }

        public static void Set(string name, Function function)
        {
            _functions[name] = function;
        }
    }
}
