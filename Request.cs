using System;
using System.Data.SqlClient;
using Telegram.Bot;

namespace KronTGHelper
{
    public class Request
    {
        public static async void NewWallets(long numberTg, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = $"INSERT INTO Wallets(NumberTg, BSC, MATIC, AVACX, SOL, TRX, ETH) VALUES('{numberTg}', '-', '-', '-', '-', '-', '-')";

            command.Connection = connection;

            await command.ExecuteNonQueryAsync();
        }
        public static async void NewUser(string numberTg, string userName, string invited, string brought, double deposit, double balance, string wallet, int bonus, int withdrawl, SqlConnection connection)
        {
            string date = DateTime.Now.ToString("dd-M-yyyy");

            SqlCommand command = new SqlCommand();

            command.CommandText = $"INSERT INTO USERSPRO(NumberTg, Name, Invited, Brought, Deposit, Balance, Registr, Wallet, Bonus, Withdrawl) VALUES('{numberTg}', '{userName}', '{invited}', '{brought}', {deposit}, {balance}, '{date}', '{wallet}', {bonus}, {withdrawl})";

            command.Connection = connection;

            await command.ExecuteNonQueryAsync();
        }
        public static async void DeleteUser(string numberTg, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = $"DELETE FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            command.Connection = connection;

            await command.ExecuteNonQueryAsync();
        }
        public static async void EditBalance(long numberTg, double balance, SqlConnection connection)
        {
            string sql = $"UPDATE USERSPRO SET Balance = Balance + {balance} WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            await command.ExecuteNonQueryAsync();
        }
        public static string CheckingBalance(long numberTg, SqlConnection connection)
        {
            
            string sql = $"SELECT Balance FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string balance = command.ExecuteScalar().ToString();

            return balance;
        }
        public static string CheckingName(long numberTg, SqlConnection connection)
        {

            string sql = $"SELECT Name FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string name = command.ExecuteScalar().ToString();

            return name;
        }
        public static string CheckingDepo(long numberTg, SqlConnection connection)
        {

            string sql = $"SELECT Deposit FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string deposit = command.ExecuteScalar().ToString();

            return deposit;
        }
        public static string CheckingRego(long numberTg, SqlConnection connection)
        {

            string sql = $"SELECT Registr FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string reg = command.ExecuteScalar().ToString();

            return reg;
        }
        public static string CheckingWallet(long numberTg, SqlConnection connection)
        {
            string sql = $"SELECT Wallet FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string wal = command.ExecuteScalar().ToString();

            return wal;
        }
        public static string CheckingBrought(long numberTg, SqlConnection connection)
        {

            string sql = $"SELECT Brought FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string bro = command.ExecuteScalar().ToString();

            return bro;
        }
        public static string CheckingInvited(long numberTg, SqlConnection connection)
        {

            string sql = $"SELECT Invited FROM USERSPRO WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string bro = command.ExecuteScalar().ToString();

            return bro;
        }
        public static string CheckingBonus(long tgNumber, SqlConnection connection)
        {

            string sql = $"SELECT Bonus FROM USERSPRO WHERE NumberTg = '{tgNumber}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string bonus = command.ExecuteScalar().ToString();

            return bonus;
        }
        public static void EditBrought(string numberTg, string brought, SqlConnection connection)
        {
            string preBrought = CheckingBrought(Convert.ToInt64(numberTg), connection);

            brought = preBrought + brought + ";";

            string sql = $"UPDATE USERSPRO SET Brought = '{brought}' WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            command.ExecuteNonQueryAsync();
        }
        public static void EditWallet(long numberTg, string wallet, SqlConnection connection)
        {
            string sql = $"UPDATE USERSPRO SET Wallet = '{wallet}' WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            command.ExecuteNonQueryAsync();
        }
        public static void EditInvited(long numberTg, string invited, SqlConnection connection)
        {
            string sql = $"UPDATE USERSPRO SET Invited = '{invited}' WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            command.ExecuteNonQueryAsync();
        }
        public static void EditBonus(long numberTg, int bonus, SqlConnection connection)
        {
            string sql = $"UPDATE USERSPRO SET Bonus = {bonus} WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            command.ExecuteNonQueryAsync();
        }
        public static bool Withdrawl(long numberTg, string summ, string nameNet, SqlConnection connection, ITelegramBotClient client)
        {
            double balance = Convert.ToDouble(CheckingBalance(numberTg, connection));
            double summd = Convert.ToDouble(summ);
            string wallet = CheckingWallets(numberTg, nameNet, connection);
            if (summd > 0 && summd < balance)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = $"INSERT INTO Withdrawl(NumberTg, Summ, Wallet, Net) VALUES('{numberTg}', {summd}, '{wallet}', '{nameNet}')";

                command.Connection = connection;

                command.ExecuteNonQueryAsync();

                EditBalance(numberTg, 0 - summd, connection);
                client.SendTextMessageAsync(323125598, $"Вывод от {CheckingName(numberTg, connection)} на сумму {summd} BUSD\nКошелёк: {wallet}\nСеть: {nameNet}");
                client.SendTextMessageAsync(958529372, $"Вывод от {CheckingName(numberTg, connection)} на сумму {summd} BUSD\nКошелёк: {wallet}\nСеть: {nameNet}");
                return true;
            }
            else if(summd < 0)
            {
                TelegramBot.Message(numberTg, "Думаешь один такой умный)");
                return false;
            }
            else
            {
                return false;
            }
        }
        public static string CheckingWallets(long numberTg, string nameNet, SqlConnection connection)
        {
            string sql = $"SELECT {nameNet} FROM Wallets WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            string wal = command.ExecuteScalar().ToString();

            return wal;
        }
        public static void EditWallets(long numberTg, string nameNet, string wallet, SqlConnection connection)
        {
            string sql = $"UPDATE Wallets SET {nameNet} = '{wallet}' WHERE NumberTg = '{numberTg}'";

            SqlCommand command = new SqlCommand(sql, connection);

            command.ExecuteNonQueryAsync();
        }
    }
}