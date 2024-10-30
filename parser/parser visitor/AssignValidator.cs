using DSL.ast;
using DSL.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.parser_visitor
{
    internal class AssignValidator : Visitor
    {
        public void visit(ArrayAccessExpression s)
        {
            foreach (Expression index in s._indices)
            {
                index.Accept(this);
            }
        }

        public void visit(ArrayAssignmentStatement s)
        {
            s.array.Accept(this);
            s._expression.Accept(this);
        }

        public void visit(ArrayExpression s)
        {
            foreach (Expression index in s._elements)
            {
                index.Accept(this);
            }
        }

        public void visit(AssignmentStatement s)
        {
            s._expression.Accept(this);
            if(Variables.IsExists(s._variable))
            {
                throw new Exception("Cannot assign value to constant");
            }
            
        }

        public void visit(BinaryExpression s)
        {
            s._expr1.Accept(this);
            s._expr2.Accept(this);
        }

        public void visit(BlockStatement s)
        {
            foreach (Statement statement in s._statements)
            {
                statement.Accept(this);
            }
        }

        public void visit(BreakStatement s)
        {
        }

        public void visit(ConditionalExpression s)
        {
            s._expr1.Accept(this);
            s._expr2.Accept(this);
        }

        public void visit(ContinueStatement s)
        {
        }

        public void visit(DoWhileStatement s)
        {
            s._condition.Accept(this);
            s._statement.Accept(this);
        }

        public void visit(ForStatement s)
        {
            s.Initialization.Accept(this);
            s.Termination.Accept(this);
            s.Increment.Accept(this);
            s.Statement.Accept(this);
        }

        public void visit(FunctionDefineStatement s)
        {
            s._body.Accept(this);
        }

        public void visit(FunctionStatement s)
        {
            s._function.Accept(this);
        }

        public void visit(FunctionalExpression s) // возможна ошибка
        {
            for (int i = 0; i < s._arguments.Count; i++)
            {
                s._arguments[i].Accept(this);
            }
        }

        public void visit(IfStatement s)
        {
            s._expression.Accept(this);
            s._ifStatement.Accept(this);
            if (s._elseStatement != null)
            {
                s._elseStatement.Accept(this);
            }
        }

        public void visit(PrintStatement s)
        {
            s._expression.Accept(this);
        }

        public void visit(ReturnStatement s)
        {
        }

        public void visit(UnaryExpression s)
        {
            s._expr1.Accept(this);
        }

        public void visit(ValueExpression s)
        {
        }

        public void visit(VariableExpression s)
        {
            Console.WriteLine(s._name.ToString());

        }

        public void visit(WhileStatement st)
        {
            st._condition.Accept(this);
            st._statement.Accept(this);
        }

        public void visit(UseStatement st)
        {
        }

        public void visit(TrueStatement s)
        {
        }

        public void visit(FalseStatement s)
        {
        }
    }
}
