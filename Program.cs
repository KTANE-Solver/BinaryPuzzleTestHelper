using System.Diagnostics.SymbolStore;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace BinaryPuzzleTestHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter log = new StreamWriter("dummy.txt");

            string given = "?\t?\t?\t1\t?\t?\r\n?\t?\t?\t?\t?\t?\r\n1\t1\t?\t?\t?\t?\r\n1\t?\t?\t1\t?\t?\r\n?\t?\t0\t?\t?\t?\r\n?\t?\t?\t?\t0\t0".Replace("?", "-").Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("\n", "");

            string answer = "0\t0\t1\t1\t0\t1\r\n0\t0\t1\t0\t1\t1\r\n1\t1\t0\t0\t1\t0\r\n1\t0\t1\t1\t0\t0\r\n0\t1\t0\t0\t1\t1\r\n1\t1\t0\t1\t0\t0".Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("\n", "");

            if (given.Length != 36 || answer.Length != 36)
            {
                throw new Exception();
            }

            log.AutoFlush = true;

            PrintGrid(log, given, false);
            log.Write("\n");
            PrintGrid(log, answer, true);

        }

        public static void PrintGrid(StreamWriter log, string str, bool answer)
        {
            log.Write($"char[,] {(answer ? "answer" : "grid")} = new char[6, 6]\n{{\n");

            for (int i = 0; i < 6; i++)
            {
                log.Write($"\t{{");
                for (int j = 0; j < 6; j++)
                {
                    log.Write($"'{str[i * 6 + j]}'");

                    if (j != 5)
                    {
                        log.Write(",");
                    }

                    else
                    { 
                        log.Write($"}}");
                    }
                }


                if (i != 5)
                {
                    log.Write($",\n");
                }

                else
                {
                    log.Write("\n};");
                }
                
            }
        }

        public static void PrintLog(string s, StreamWriter log)
        {
            Console.Write(s);
            log.Write(s);
        }
    }
}