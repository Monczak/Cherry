using System;
using Cherry.Language;

namespace Cherry
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"
func foo(bar) {
let arr = [0, 1, 2, 3e45, 1.23]
let str = 'Hello world! I am Test 341e-3.'
return bar+arr
}
";
            Lexer.Parse(input);
            Console.ReadKey();
        }
    }
}
