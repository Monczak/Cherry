using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text;

namespace Cherry.Language
{
    class Lexer
    {
        public static List<Token> Parse(string input)
        {
            List<Token> tokens = new List<Token>();

            // Split input by delimiters
            List<string> splitInput = Regex.Split(input, TokenPatterns.DelimiterPattern, RegexOptions.Compiled | RegexOptions.Multiline).ToList();

            // Consolidate strings
            bool inString = false;
            int startIndex = 0;
            for (int i = 0; i < splitInput.Count; i++)
            {
                if (splitInput[i] == "'")
                {
                    inString = !inString;
                    if (inString) startIndex = i;
                    else
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int j = startIndex + 1; j < i; j++)
                            builder.Append(splitInput[j]);

                        splitInput[startIndex + 1] = builder.ToString();

                        for (int j = startIndex + 2; j < i; j++)
                            splitInput.RemoveAt(startIndex + 2);
                    }
                }
                
            }

            splitInput.RemoveAll(x => string.IsNullOrWhiteSpace(x));

            for (int i = 0; i < splitInput.Count; i++)
            {
                string s = splitInput[i];

                TokenType type = TokenType.Invalid;

                if (s == "\'" || s == "\"") inString = !inString;

                if (IsKeyword(s)) type = TokenType.Keyword;
                else if (IsQuote(s)) type = TokenType.Quote;
                else if (i > 0 && i < splitInput.Count && IsQuote(splitInput[i - 1]) && IsQuote(splitInput[i + 1]) && splitInput[i - 1] == splitInput[i + 1]) type = TokenType.String;
                else if (IsComma(s)) type = TokenType.Comma;
                else if (IsValidNumber(s)) type = TokenType.Number;
                else if (IsValidIdentifier(s)) type = TokenType.Identifier;

                tokens.Add(new Token(type, s));
                Console.WriteLine($"{s} - {tokens[tokens.Count - 1].type}");
            }

            return tokens;
        }

        static bool IsKeyword(string str)
        {
            return TokenPatterns.Keywords.Contains(str);
        }

        static bool IsQuote(string str)
        {
            return str == "\"" || str == "'";
        }

        static bool IsComma(string str)
        {
            return str == ",";
        }

        static bool IsValidIdentifier(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            if (!char.IsLetter(str[0]) && str[0] != '_') return false;

            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetterOrDigit(str[i]) && str[i] != '_') return false;

            return true;
        }

        static bool IsValidNumber(string str)
        {
            return double.TryParse(str, out _);
        }

    }
}
