﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class BreakStatement : Exception, Statement 
    {
        public void execute()
        {
            throw this;
        }

        public override string ToString()
        {
            return "break";
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }

    }
}
