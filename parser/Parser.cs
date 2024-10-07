using DSL.ast;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DSL.parser
{
    public class Parser
    {
        private static Token EOF = new Token(TokenType.EOF, "");

        private List<Token> _tokens;
        private int _pos, _size;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _size = _tokens.Count;
        }

        public Statement Parse()
        {
            BlockStatement result = new BlockStatement();
            while (!Match(TokenType.EOF))
            {
                result.Add(Statement());
            }
            return result;
        }

        private Statement Block()
        {
            BlockStatement block = new BlockStatement();  
            Consume(TokenType.LBRACE);
            while (!Match(TokenType.RBRACE))
            {
                block.Add(Statement());
            }
            return block;
        }

        private Statement Statement()
        {
            if (Match(TokenType.PRINT))
            {
                return new PrintStatement(Expression());
            }
            if (Match(TokenType.IF))
            {
                return IfElse();
            }
            if (Match(TokenType.DO))
            {
                return DoWhileStatement();
            }
            if (Match(TokenType.WHILE))
            {
                return WhileStatement();
            }
            if (Match(TokenType.FOR))
            {
                return ForStatement();
            }
            if (Match(TokenType.BREAK))
            {
                return new BreakStatement();
            }
            if (Match(TokenType.CONTINUE))
            {
                return new ContinueStatement();
            }
            if (Match(TokenType.DEF))
            {
                return FunctionDefine();
            }
            if (Match(TokenType.RETURN))
            {
                return new ReturnStatement(Expression());
            }
            if (Get(0).Get_Type() == TokenType.WORD && Get(1).Get_Type() == TokenType.LPAREN)
            {
                return new FunctionStatement(Function());
            }
            return AssigmentStatement();
        }

        private Statement AssigmentStatement()
        {
            Token current = Get(0);
            if(LookMatch(0, TokenType.WORD) && LookMatch(1, TokenType.EQ))
            {
                string variable = Consume(TokenType.WORD).Get_Text();
                Consume(TokenType.EQ);
                return new AssignmentStatement(variable, Expression());
            }
            if(LookMatch(0, TokenType.WORD) && LookMatch(1, TokenType.LBRACKET))
            {
                ArrayAccessExpression array = Element();
                Consume(TokenType.EQ);
                return new ArrayAssigmentStatement(array, Expression());
            }
            throw new Exception("Unknow statement");
        }

        private Statement IfElse()
        {
            Expression condition = Expression();
            Statement ifStatement = StatementOrBlock();
            Statement elseStatement;
            if (Match(TokenType.ELSE))
            {
                elseStatement = StatementOrBlock();
            }
            else
            {
                elseStatement = null;
            }
            return new IfStatement(condition, ifStatement, elseStatement);
        }

        private Statement DoWhileStatement()
        {
            Statement statement = StatementOrBlock();
            Consume(TokenType.WHILE);
            Expression condition = Expression();
            return new DoWhileStatement(condition, statement);
        }

        private Statement WhileStatement()
        {
            Expression condition = Expression();
            Statement statement = StatementOrBlock();
            return new WhileStatement(condition, statement);
        }

        private Statement ForStatement()
        {
            Statement initialization = AssigmentStatement();
            Expression termination = Expression();
            Statement increment = AssigmentStatement();
            Statement statement = StatementOrBlock();
            return new ForStatement(initialization, termination, increment, statement);
        }

        private Statement StatementOrBlock()
        {
            if(Get(0).Get_Type() == TokenType.LBRACE)
            {
                return Block();
            }
            else
            {
                return Statement();
            }
        }

        private FunctionalDefineStatement FunctionDefine()
        {
            string name = Consume(TokenType.WORD).Get_Text();
            Consume(TokenType.LPAREN);
            FunctionalExpression function = new FunctionalExpression(name);
            List<string> argNames = new List<string>();
            while (!Match(TokenType.RPAREN))
            {
                argNames.Add(Consume(TokenType.WORD).Get_Text());
                Match(TokenType.COMMA);
            }
            Statement body = StatementOrBlock();
            return new FunctionalDefineStatement(name, argNames, body);
        }

        private FunctionalExpression Function()
        {
            string name = Consume(TokenType.WORD).Get_Text();
            Consume(TokenType.LPAREN);
            FunctionalExpression function = new FunctionalExpression(name);
            while (!Match(TokenType.RPAREN))
            {
                function.AddArgument(Expression());
                Match(TokenType.COMMA);
            }
            return function;
        }

        private ArrayAccessExpression Element()
        {
            string variable = Consume(TokenType.WORD).Get_Text();
            List<Expression> indices = new List<Expression>();
            do
            {
                Consume(TokenType.LBRACKET);
                indices.Add(Expression());
                Consume(TokenType.RBRACKET);
            } 
            while(LookMatch(0, TokenType.LBRACKET));
            
            return new ArrayAccessExpression(variable, indices);
        }

        private Expression Arr()
        {
            Consume(TokenType.LBRACKET);
            List<Expression> elements = new List<Expression>();
            while (!Match(TokenType.RBRACKET))
            {
                elements.Add(Expression());
                Match(TokenType.COMMA);
            }
            return new ArrayExpression(elements);
        }

        private Expression Expression()
        {
            return LogicalOr();
        }

        private Expression LogicalOr()
        {
            Expression result = LogicalAnd();

            while (true)
            {
                if (Match(TokenType.BARBAR))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.OR, result, LogicalAnd());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression LogicalAnd()
        {
            Expression result = Equality();

            while (true)
            {
                if (Match(TokenType.AMPAMP))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.AND, result, Equality());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression Equality() 
        {
            Expression result = Conditional();

            if (Match(TokenType.EQEQ))
            {
                return new ConditionalExpression(ConditionalExpression.Operator.EQUALS, result, Conditional());
            }
            if (Match(TokenType.EXCLEQ))
            {
                return new ConditionalExpression(ConditionalExpression.Operator.NOT_EQUALS, result, Conditional());
            }
            return result;
        }

        private Expression Conditional()
        {
            Expression result = Additive();

            while (true)
            {
                if (Match(TokenType.LT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.LT, result, Additive());
                    continue;
                }
                if (Match(TokenType.LTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.LTEQ, result, Additive());
                    continue;
                }
                if (Match(TokenType.GT))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.GT, result, Additive());
                    continue;
                }
                if (Match(TokenType.GTEQ))
                {
                    result = new ConditionalExpression(ConditionalExpression.Operator.GTEQ, result, Additive());
                    continue;
                }
                break;
            }
            return result;
        }

        private Expression Additive()
        {
            Expression result = Multiplicative();

            while (true)
            {
                if (Match(TokenType.PLUS))
                {
                    result = new BinaryExpression('+', result, Multiplicative());
                    continue;
                }
                if (Match(TokenType.MINUS))
                {
                    result = new BinaryExpression('-', result, Multiplicative());
                    continue;
                }
                break;
            }
            return result;
        }

        private Expression Multiplicative()
        {
            Expression result = Unary();

            while (true)
            {
                if (Match(TokenType.STAR))
                {
                    result = new BinaryExpression('*', result, Unary());
                    continue;
                }
                if (Match(TokenType.SLASH))
                {
                    result = new BinaryExpression('/', result, Unary());
                    continue;
                }
                break;
            }
            return result;
        }

        private Expression Unary()
        {
            if (Match(TokenType.MINUS))
            {
                return new UnaryExpression('-', Primary());
            }
            if (Match(TokenType.PLUS))
            {
                return Primary();
            }
            return Primary();
        }

        private Expression Primary()
        {
            Token current = Get(0);
            if (Match(TokenType.NUMBER)){
                return new ValueExpression(Convert.ToDouble(current.Get_Text()));
            }
            if (Match(TokenType.HEX_NUMBER))
            {
                return new ValueExpression(Convert.ToInt64(current.Get_Text(), 16));
            }
            if (LookMatch(0, TokenType.WORD) && LookMatch(1, TokenType.LPAREN))
            {
                return Function();
            }
            if (LookMatch(0, TokenType.WORD) && LookMatch(1, TokenType.LBRACKET))
            {
                return Element();
            }
            if (LookMatch(0, TokenType.LBRACKET))
            {
                return Arr();
            }
            if (Match(TokenType.WORD))
            {
                return new VariableExpression(current.Get_Text());
            }
            if (Match(TokenType.TEXT))
            {
                return new ValueExpression(current.Get_Text());
            }
            if (Match(TokenType.LPAREN))
            {
                Expression result = Expression();
                Match(TokenType.RPAREN);
                return result;
            }
            throw new Exception("Unknown expression");
        }

        private Token Consume(TokenType type)
        {
            Token current = Get(0);
            if (type != current.Get_Type())
            {
                throw new Exception("Token " + current.Get_Type() + " doesn't match " + type);
            }
            _pos++;
            return current;
        }

        private bool Match(TokenType type)
        {
            Token current = Get(0);
            if (type != current.Get_Type()) return false;
            _pos++;
            return true;
        }

        private bool LookMatch(int position, TokenType type)
        {
            return Get(position).Get_Type() == type;
        }

        private Token Get(int relative_position)
        {
            int position = _pos + relative_position;
            if (position >= _size) return EOF;
            return _tokens[position];
        }
    }
}
