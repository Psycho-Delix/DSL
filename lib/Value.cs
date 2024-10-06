using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public interface Value
    {
        double AsDouble();
        string AsString();
    }
}
