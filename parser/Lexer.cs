using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.parser
{
    public class Lexer
    {
        private static readonly string OPERATOR_CHARS = "+-*/(){}[]=<>!&|,:.";
        private int _line_number = 1;

        public int LineNumber { get => _line_number; }

        private static Dictionary<string, TokenType> OPERATORS = new Dictionary<string, TokenType>()
        {
            {"+", TokenType.PLUS},
            {"-", TokenType.MINUS},
            {"*", TokenType.STAR},
            {"/", TokenType.SLASH},
            {"(", TokenType.LPAREN},
            {")", TokenType.RPAREN},
            {"{", TokenType.LBRACE},
            {"}", TokenType.RBRACE},
            {"[", TokenType.LBRACKET},
            {"]", TokenType.RBRACKET},
            {"=", TokenType.EQ},
            {"<", TokenType.LT},
            {">", TokenType.GT},
            {",", TokenType.COMMA},

            {"!", TokenType.EXCL},
            {"&", TokenType.AMP},
            {"|", TokenType.BAR},

            {"==", TokenType.EQEQ},
            {"!=", TokenType.EXCLEQ},
            {"<=", TokenType.LTEQ},
            {">=", TokenType.GTEQ},

            {"&&", TokenType.AMPAMP},
            {"||", TokenType.BARBAR},
            {":", TokenType.COLON},
            {".", TokenType.DOT}
        };

        private string _input;
        private List<Token> _tokens;

        private int _pos;
        private int _lenght;


        public Lexer(string input)
        {
            _input = input;
            _lenght = input.Length;

            _tokens = new List<Token>();
        }

        public List<Token> Tokenize()
        {
            while (_pos < _lenght)
            {
                char current = Peek(0);
                if (char.IsDigit(current)) TokenizeNumber();
                else if (char.IsLetter(current)) TokenizeWord();
                else if (current == '\n')
                {
                    Next();
                    _line_number++;
                }
                else if (current == '#')
                {
                    Next();
                    TokenizeHexNumber();
                }
                else if (current == '"')
                {
                    Next();
                    TokenizeText();
                }
                else if (OPERATOR_CHARS.IndexOf(current) != -1)
                {
                    TokenizeOperator();
                }
                else Next();
            }
            return _tokens;
        }


        private void TokenizeNumber()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);

            while (true)
            {
                if (current == ',')
                {
                    if (buffer.ToString().IndexOf(',') != -1) throw new Exception("Invalid float number");
                }
                else if (!char.IsDigit(current))
                {
                    break;
                }
                buffer.Append(current);
                current = Next();
            }
            AddToken(TokenType.NUMBER, buffer.ToString());
        }


        private void TokenizeHexNumber()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);
            while (char.IsDigit(current) || IsHexNumber(current))
            {
                buffer.Append(current);
                current = Next();
            }
            AddToken(TokenType.HEX_NUMBER, buffer.ToString());
        }

        private static bool IsHexNumber(char current)
        {
            return "abcdef".IndexOf(char.ToLower(current)) != -1;
        }

        private void TokenizeOperator()
        {
            char current = Peek(0);
            if(current == '/')
            {
                if(Peek(1) == '/')
                {
                    Next();
                    Next();
                    TokenizeComment();
                    return;
                }
                else if (Peek(1) == '*')
                {
                    Next();
                    Next();
                    TokenizeMultilineComment();
                    return;
                }
            }
            StringBuilder buffer = new StringBuilder();
            while (true)
            {
                string text = buffer.ToString();
                if (!OPERATORS.ContainsKey(text + current) && !string.IsNullOrEmpty(text))
                {
                    AddToken(OPERATORS[text]);
                    return;
                }
                buffer.Append(current);
                current = Next();   
            }

        }

        private void TokenizeWord()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);

            while (true)
            {
                if (!char.IsLetterOrDigit(current) && (current != '_') && (current != '$'))
                {
                    break;
                }
                buffer.Append(current);
                current = Next();
            }

            string word = buffer.ToString();
            switch (word)
            {
                case "print": AddToken(TokenType.PRINT); break;
                case "if": AddToken(TokenType.IF); break;
                case "else": AddToken(TokenType.ELSE); break;
                case "while": AddToken(TokenType.WHILE); break;
                case "for": AddToken(TokenType.FOR); break;
                case "do": AddToken(TokenType.DO); break;
                case "break": AddToken(TokenType.BREAK); break;
                case "continue": AddToken(TokenType.CONTINUE); break;
                case "def": AddToken(TokenType.DEF); break;
                case "return": AddToken(TokenType.RETURN); break;
                case "use": AddToken(TokenType.USE); break;
                case "true": AddToken(TokenType.TRUE); break;
                case "false": AddToken(TokenType.FALSE); break;
                case "enum": AddToken(TokenType.ENUM); break;
                default:
                    AddToken(TokenType.WORD, word);
                    break;
            }
        }

        private void TokenizeText()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);

            while (true)
            {
                if(current == '\\')
                {
                    current = Next();
                    switch (current)
                    {
                        case '"': current = Next(); buffer.Append('"'); continue;
                        case 'n': current = Next(); buffer.Append('\n'); continue;
                        case 't': current = Next(); buffer.Append('\t'); continue;
                    }
                    buffer.Append('\\');
                    continue;
                }
                if (current == '"') break;
                buffer.Append(current);
                current = Next();
            }
            Next(); // skip closing "

            AddToken(TokenType.TEXT, buffer.ToString());
        }

        private void TokenizeComment()
        {
            char current = Peek(0);
            while("\r\n\0".IndexOf(current) == -1)
            {
                current = Next();
            }
        }

        private void TokenizeMultilineComment()
        {
            char current = Peek(0);
            while (true)
            {
                if (current == '\0') throw new Exception("Missing close tag");
                if (current == '*' && Peek(1) == '/') break; 
                current = Next();
            }
            Next(); // *
            Next(); // /
        }

        private char Next()
        {
            _pos++;
            return Peek(0);
        }

        private char Peek(int relative_position)
        {
            int position = _pos + relative_position;
            if (position >= _lenght) return '\0';
            return _input[position];
        }

        private void AddToken(TokenType type)
        {
            AddToken(type, "");
        }

        private void AddToken(TokenType type, string text)
        {
            _tokens.Add(new Token(type, text, _line_number));
        }
    }
}
