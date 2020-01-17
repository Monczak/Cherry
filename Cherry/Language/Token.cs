using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cherry.Language
{
    class Token
    {
        public TokenType type;
        public string str;

        public Token(TokenType t, string s)
        {
            type = t;
            str = s;
        }
    }

    public enum TokenType
    {
        Keyword,
        Identifier,
        Number,
        String,
        Operator,
        Assignment,
        LeftParenthesis,
        RightParenthesis,
        LeftBracket,
        RightBracket,
        LeftBrace,
        RightBrace,
        Comma,
        Quote,
        Invalid
    }
}
