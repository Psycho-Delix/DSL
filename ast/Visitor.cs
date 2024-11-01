﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DSL.ast
{
    public interface Visitor
    {
        void visit(ArrayAccessExpression s);
        void visit(ArrayAssignmentStatement s);
        void visit(ArrayExpression s);
        void visit(AssignmentStatement s);
        void visit(BinaryExpression s);
        void visit(BlockStatement s);
        void visit(BreakStatement s);
        void visit(ConditionalExpression s);
        void visit(ContinueStatement s);
        void visit(DoWhileStatement s);
        void visit(ForStatement s);
        void visit(FunctionDefineStatement s);
        void visit(FunctionStatement s);
        void visit(FunctionalExpression s);
        void visit(IfStatement s);
        void visit(PrintStatement s);
        void visit(ReturnStatement s);
        void visit(UnaryExpression s);
        void visit(ValueExpression s);
        void visit(VariableExpression s);
        void visit(WhileStatement st);
        void visit(UseStatement s);
        void visit(TrueStatement s);
        void visit(FalseStatement s);
    }
}
