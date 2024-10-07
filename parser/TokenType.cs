using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL.parser
{
    public enum TokenType
    {
        NUMBER,
        HEX_NUMBER,
        WORD,
        TEXT,

        //keyword
        PRINT,
        IF,
        ELSE,
        WHILE,
        FOR,
        DO,
        BREAK,
        CONTINUE,
        DEF,
        RETURN,

        //operator
        PLUS, 
        MINUS,
        STAR,
        SLASH,
        EQ,
        EQEQ,
        EXCL,
        EXCLEQ,
        LTEQ,
        LT,
        GT,
        GTEQ,

        BAR, // &
        BARBAR, // &&
        AMP, // |
        AMPAMP, // ||

        LPAREN, // (
        RPAREN, // )
        LBRACE, // {
        RBRACE, // }
        LBRACKET, // [
        RBRACKET, // ]
        COMMA, // ,

        EOF
    }
}
