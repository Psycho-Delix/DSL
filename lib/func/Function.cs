using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib
{
    public interface Function
    {
        Value Execute(params Value[] args);
    }

}
