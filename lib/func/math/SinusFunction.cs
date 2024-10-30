﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.lib.func.math
{
    public class SinusFunction : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new NumberValue(Math.Sin(args[0].AsDouble()));
        }
    }
}