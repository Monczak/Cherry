using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cherry.Language
{
    class TokenPatterns
    {
        public static string DelimiterPattern = @"(\(|\)|\[|\]|\{|\}|\ |\+|\-|\*|\/|\=|\<|\>|\,|\%|\'|\n)";
        public static char[] Operators = "+-*/<>=%".ToCharArray();

        public static string[] Keywords =
        {
            "let",
            "func",
            "if",
            "while",
            "for",
            "in",
            "to",
            "return",
            "not",
            "and",
            "or",
            "xor",
            "continue",
            "break",
            "else",
            "do",
            "switch",
            "case",
            "default",
            "true",
            "false"
        };
    }
}
