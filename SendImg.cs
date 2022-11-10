using System;
using System.Drawing;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace KronTGHelper
{
    public class SendImg
    {
        public async static void Information(Message message, ITelegramBotClient bot, ReplyKeyboardMarkup replyKeyboardMarkupBack)
        {
            long numtg = message.Chat.Id;
            double balance = Convert.ToDouble(Request.CheckingBalance(numtg, Program.connection));
            double deposit = Convert.ToDouble(Request.CheckingDepo(numtg, Program.connection));
            double pnl = ((balance / deposit) - 1) * 100;
            pnl = Math.Round(pnl, 2);
            string profit = Convert.ToString(pnl);
            profit = profit + " %";
            string uppath = Environment.CurrentDirectory + $@"\MainPic\Balance.png";
            string uppath2 = Environment.CurrentDirectory + @$"\MainPic\Balance{numtg}.png";

            Image fon = Image.FromFile(uppath);

            using (Graphics g = Graphics.FromImage(fon))
            {
                g.DrawString(profit, new Font("Century Gothic", 18.0F, FontStyle.Bold), new SolidBrush(Color.White), new Point(1230, 264));
                fon.Save(uppath2);
            }
            using (var fileStream = new FileStream(uppath2, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream)
                );
            }
        }
        public async static void Wallet(Message message, ITelegramBotClient bot, ReplyKeyboardMarkup replyKeyboardMarkupCabinet)
        {
            long numtg = message.Chat.Id;
            double balance = Convert.ToDouble(Request.CheckingBalance(numtg, Program.connection));
            double deposit = Convert.ToDouble(Request.CheckingDepo(numtg, Program.connection));
            double pnl = ((balance / deposit) - 1) * 100;
            pnl = Math.Round(pnl, 2);
            string profit = Convert.ToString(pnl);
            profit = profit + " %";
            string uppath = Environment.CurrentDirectory + @$"\MainPic\Wallet.png";
            string uppath2 = Environment.CurrentDirectory + @$"\MainPic\Wallet{numtg}.png";

            Image fon = Image.FromFile(uppath);

            using (Graphics g = Graphics.FromImage(fon))
            {
                g.DrawString(profit, new Font("Century Gothic", 18.0F, FontStyle.Bold), new SolidBrush(Color.White), new Point(1230, 264));
                fon.Save(uppath2);
            }
            using (var fileStream = new FileStream(uppath2, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                 await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    //caption: $"Ваш личный кабинет\n\nДата регистрации: {Request.CheckingRego(message.Chat.Id, Program.connection)}\nТвой ID: {message.Chat.Id}",
                    photo: new InputOnlineFile(fileStream)
                );
            }

            await bot.SendTextMessageAsync(message.Chat, $"Ваш личный кабинет\n\nДата регистрации: {Request.CheckingRego(message.Chat.Id, Program.connection)}\nТвой ID: <pre><s>{message.Chat.Id}</s></pre>", replyMarkup: replyKeyboardMarkupCabinet, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
        }
    }
}
