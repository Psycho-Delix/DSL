using DSL.lib.func.array;
using DSL.lib.func.cast;
using DSL.lib.func.file;
using DSL.lib.func.math;
using DSL.lib.func.str;
using DSL.lib.func.system;
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
        public static Dictionary<string, Function> _functions = new Dictionary<string, Function>()
        {
            {"num", new ConvertToNumFunction() },
            {"str", new ConvertToStringFunction() },
            {"round", new RoundFunction() },
            {"floor", new FloorFunction() },
            {"ceil", new CeilFunction() },
            {"mod", new ModFunction() },
            {"isStr", new IsStringFunctin() },
            {"isNum", new IsNumberFunction() },
            {"isEval", new IsEvalFunction() },
            {"isOdd", new IsOddFunction() },
            {"isPrime", new IsPrimaryFunction() },
            {"isEmpty", new IsEmptyFunction() },
            {"compat", new CompatFunction() },
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
