using DSL.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSL.ast;
using DSL.lib;
using System.IO;
using DSL.parser_visitor;

namespace DSL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string v;
            string path = File.ReadAllText("C:\\Users\\nkoper\\source\\repos\\IDE\\IDE\\bin\\Debug\\path.txt");

            try
            {
                //string fileName = Console.ReadLine();
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), path);

                using (FileStream fs = File.OpenRead(filePath))
                {
                    byte[] fileBytes = new byte[fs.Length];
                    fs.Read(fileBytes, 0, fileBytes.Length);

                    v = Encoding.UTF8.GetString(fileBytes);


                    /////////////////////////////////////////////

                    string input = v;

                    List<Token> tokens = new Lexer(input).Tokenize();

                    /*foreach (Token token in tokens)
                    {
                        Console.WriteLine(token.Get_Type() + " " + token.Get_Text());
                    }*/

                    Statement program = new Parser(tokens).Parse();

                    program.Accept(new FunctionAdder());
                    //program.Accept(new AssignValidator());

                   // program.execute();

                    try
                    {
                        program.execute();
                    }
                    catch (Exception ex)
                    {
                        int lineNumber = tokens.LastOrDefault()?.LineNumber ?? 0;

                        Console.WriteLine($"Ошибка на строке {lineNumber}: {ex.Message}");
                    }

                    string next = Console.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
            }
        }
    }
}