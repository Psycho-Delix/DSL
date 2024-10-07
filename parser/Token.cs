using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.parser
{
    public class Token
    {
        private TokenType _type;
        private string _text;

        public Token() {}

        public Token(TokenType type, string text)
        {
            _type = type;
            _text = text;
        }

        public TokenType Get_Type()
        {
            return _type;
        }

        public string Get_Text()
        {
            return _text;
        }
    }
}
