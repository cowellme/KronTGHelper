using System;
using System.IO;

namespace KronTGHelper
{
    public class Logger
    {
        public static void Error(Exception ex)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:fff");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message + "      " + date);
            Console.ResetColor();
            File.AppendAllText(Environment.CurrentDirectory + @"\Logs\Errors.txt", ex.Message + " " + date);
        }
        public static void Info(string text)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:fff");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text + "      " + date);
            Console.ResetColor();
            File.AppendAllText(Environment.CurrentDirectory + @"\Logs\Info.txt", text + " " + date);
        }
        public static void Access(string text)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:fff");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text + "      " + date);
            Console.ResetColor();
            File.AppendAllText(Environment.CurrentDirectory + @"\Logs\Access.txt", text + " " + date);
        }
        public static void Test(string text)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:fff");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text + "      " + date);
            Console.ResetColor();
            File.AppendAllText(Environment.CurrentDirectory + @"\Logs\Test.txt", text + " " + date);
        }
    }
}
