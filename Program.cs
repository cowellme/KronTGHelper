using System;
using System.Data.SqlClient;
using System.Configuration;


namespace KronTGHelper
{
    internal class Program
    {
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        static void Main()
        {
            connection.Open();
            //Logger.Access("App startup!");
            TelegramBot.Start();
            Console.ReadLine();
        }
    }
}
