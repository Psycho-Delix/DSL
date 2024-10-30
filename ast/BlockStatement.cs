using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.ast
{
    public class BlockStatement : Statement
    {
        public List<Statement> _statements;

        public BlockStatement()
        {
            _statements = new List<Statement>();
        }

        public void Add(Statement statement)
        {
            _statements.Add(statement);
        }

        public void execute()
        {
            foreach (Statement statement in _statements)
            {
                statement.execute();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (Statement statement in _statements)
            {
                result.Append(statement.ToString()).Append(Environment.NewLine);
            }
            return result.ToString();
        }

        public void Accept(Visitor visitor)
        {
            visitor.visit(this);
        }

    }
}
