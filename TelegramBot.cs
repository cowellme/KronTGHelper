using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace KronTGHelper
{
    internal class TelegramBot
    {

        public static ITelegramBotClient botWithdraw = new TelegramBotClient("5711255604:AAEtF0HvxEz54ykH-tAA-ys3n_65hQPDx4k");
        public static ITelegramBotClient bot = new TelegramBotClient("5503241614:AAEGfcSnbilAClw_3p6Hqo0szFreNmzoxtE");
        const string SberLogin = "401643678:TEST:6eb054a0-a469-4375-b309-a37e5a6d428b";
        public static string user = "";
        public static string[] msg = new string[2];
        public static string nameNet;

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            await Task.Run(()=>{Logger.Error(exception);});
        }
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            string depopic = Environment.CurrentDirectory + @"\MainPic\Deposit.png";
            string bindepo = Environment.CurrentDirectory + @"\MainPic\BinanceDeposit.png";
            string cabipic = Environment.CurrentDirectory + @"\MainPic\Cabinet.png";
            string infopic = Environment.CurrentDirectory + @"\MainPic\Information.png";
            string withpic = Environment.CurrentDirectory + @"\MainPic\Withdrawal.png";
            ReplyKeyboardMarkup replyKeyboardMarkupBack = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupSave = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Сохранить", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupSettings1 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Изменить Кошелёк", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupSettings2 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Сохранить", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupSettings3 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Создать кошелёк", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupReferals = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Бонус", "Пригласить", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupReferals1 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Пригласить", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupDeposit1 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Инструкция", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupDeposit2 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Desktop", "Mobile", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupCabinet = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Баланс", "Настройки",  "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupWithdrawl1 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Отправить заявку", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupWithdrawl2 = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Запросить", "Назад" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]  { new KeyboardButton[] { "Инфо ℹ️", "Рефералы 🎩", "Кошелек 💰" }, new KeyboardButton[] { "Вывод 🎁", "Пополнить 💸" } }) { ResizeKeyboard = true };
            ReplyKeyboardMarkup replyKeyboardMarkupWallets = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "ETH", "TRX", "SOL" } }) { ResizeKeyboard = true };
            try
            {
                if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                {
                    var message = update.Message;

                    msg[1] = msg[0];
                    msg[0] = message.Text;
                    
                    if (message.Text.ToLower() == "/start")
                    {
                        await bot.SendTextMessageAsync(message.Chat, "Крипто-привет!\n" +
                                                                     "KronosHelp — основной бот для взаимодействия с торговым ботом 📈\n" +
                                                                     "Тут можно:\n" +
                                                                     " • Отправить деньги на торговый счет\n" +
                                                                     " • Запросить вывод заработанных средств\n" +
                                                                     " • Просто наблюдать как растет баланс", replyMarkup: replyKeyboardMarkup);
                        
                        Request.NewUser(message.Chat.Id.ToString(), message.Chat.FirstName,"","",0.0, 0.0, "",0,0, Program.connection);
                    }

                    if (message.Text == "Настройки")
                    {
                        user = "Настройик";
                        if (Request.CheckingWallet(message.Chat.Id, Program.connection) == "yes")
                        {
                            await bot.SendTextMessageAsync(message.Chat, $"Твой кошелёк: {Request.CheckingWallet(message.Chat.Id, Program.connection)}\n" +
                            $"BSC(BEP20): {Request.CheckingWallets(message.Chat.Id, "BSC", Program.connection)}\n" +
                            $"Avaxc: {Request.CheckingWallets(message.Chat.Id, "AVACX", Program.connection)}\n" +
                            $"Matic: {Request.CheckingWallets(message.Chat.Id, "MATIC", Program.connection)}\n" +
                            $"TRX(TRC20): {Request.CheckingWallets(message.Chat.Id, "TRX", Program.connection)}\n" +
                            $"SOL: {Request.CheckingWallets(message.Chat.Id, "SOL", Program.connection)}\n" +
                            $"ETH: {Request.CheckingWallets(message.Chat.Id, "ETH", Program.connection)}\n" +
                            $"\nНастройки на {DateTime.Now.ToString("dd-M-yyyy H:mm")}", replyMarkup: replyKeyboardMarkupSettings1);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(message.Chat, $"Создай кошелёк!", replyMarkup: replyKeyboardMarkupSettings3);
                        }
                    }

                    if (message.Text == "Создать кошелёк")
                    {
                        Request.NewWallets(message.Chat.Id, Program.connection);
                        Request.EditWallet(message.Chat.Id, "yes", Program.connection);
                        await bot.SendTextMessageAsync(message.Chat, $"Готово, возвращайся в настройки", replyMarkup: replyKeyboardMarkupCabinet);
                    }

                    if (message.Text == "Изменить Кошелёк")
                    {
                        user = "Изменить Кошелёк";
                        await bot.SendTextMessageAsync(message.Chat, $"Выбери кошелёк какой сети ты хочешь изменить", replyMarkup: replyKeyboardMarkupWallets);
                    }

                    if (user == "Изменить Кошелёк" && (message.Text == "BSC" || message.Text == "MATIC" || message.Text == "ETH" || message.Text == "AVACX" || message.Text == "TRX" || message.Text == "SOL" ))
                    {
                        nameNet = message.Text;
                        await bot.SendTextMessageAsync(message.Chat, $"Введи кошлёк и нажми 'Сохранить'", replyMarkup: replyKeyboardMarkupSettings2);
                    }

                    if (message.Text == "Сохранить" && user == "Изменить Кошелёк")
                    {
                        await bot.SendTextMessageAsync(message.Chat, $"Кошелёк изменен на {msg[1]}", replyMarkup: replyKeyboardMarkupSettings1);
                        Request.EditWallets(message.Chat.Id, nameNet, msg[1], Program.connection);
                    }

                    if (message.Text == "Рефералы 🎩")
                    {
                        user = "Рефералы 🎩";
                        if (Request.CheckingBonus(message.Chat.Id, Program.connection) != "-1")
                        {
                            string z = Request.CheckingBrought(message.Chat.Id, Program.connection).Replace(";", "\n");
                            await bot.SendTextMessageAsync(message.Chat, $"Здесь твои рефераллы\n\n" +
                                                                     $"Ты Пригласил: \n{z}\n" +
                                                                     $"Тебя Пригласил: {Request.CheckingInvited(message.Chat.Id, Program.connection)}\n", replyMarkup: replyKeyboardMarkupReferals);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(message.Chat, $"Здесь твои рефераллы\n\n" +
                                                                     $"Ты Пригласил: {Request.CheckingBrought(message.Chat.Id, Program.connection)}\n" +
                                                                     $"Тебя Пригласил: {Request.CheckingInvited(message.Chat.Id, Program.connection)}\n", replyMarkup: replyKeyboardMarkupReferals1);
                        }

                    }

                    if (message.Text == "Бонус")
                    {
                        user = "Бонус";
                        await bot.SendTextMessageAsync(message.Chat, $"Введи промо-код и нажми 'Сохранить'", replyMarkup: replyKeyboardMarkupSettings2);

                    }

                    if (message.Text == "Сохранить" && user == "Бонус")
                    {
                        await bot.SendTextMessageAsync(message.Chat, $"Твой промо-код: {msg[1]}", replyMarkup: replyKeyboardMarkupReferals);
                        Request.EditInvited(message.Chat.Id, msg[1], Program.connection);
                        Request.EditBrought(msg[1], message.Chat.Id.ToString(), Program.connection);
                        Request.EditBonus(message.Chat.Id, -1, Program.connection);
                        Request.EditBalance(message.Chat.Id, 5.0, Program.connection);
                    }
                    
                    if (message.Text == "Пригласить" && user == "Рефералы 🎩")
                    {
                        await bot.SendTextMessageAsync(message.Chat, $"Привет я Kronos!\n" +
                            $"{message.Chat.FirstName} зовёт тебя инвистировать со мной\n" +
                            $"Заходи, нажимай старт и получай Бонус\n" +
                            $"Надо нажать только кнопочку 'Рефералы 🎩'\n" +
                            $"И ввести этот код: <pre language=\"c++\">{message.Chat.Id}</pre>", replyMarkup: replyKeyboardMarkupBack, parseMode: ParseMode.Html);
                    }

                    if (message.Text == "Инфо ℹ️")
                    {
                        user = "Информация";
                        using (var fileStream = new FileStream(infopic, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            await bot.SendPhotoAsync(
                                chatId: message.Chat.Id,
                                photo: new InputOnlineFile(fileStream)
                            );
                        }
                        await bot.SendTextMessageAsync(message.Chat, "Telegram канал - https://t.me/kronosBTC\n\n" +
                        "Однажды  амбициозный крипто-трейдер и расчётливый программист смешали свои знания и получился Kronos. Теперь он торгует пока все отдыхают.\n" +
                        "Читайте подробнее в FAQ телеграмм канала\n" +
                        "Ответы на часто задаваемые вопросы:\n\n" +
                        "1. Как торгует этот бот?\n" +
                        " • Собирает данные с биржи\n" +
                        " • Анализирует полученную информацию под призмой торговой стратегии.\n" +
                        " • Принимает решение ПОКУПАТЬ или ПРОДАВАТЬ\n\n" +
                        "2. Как ты можешь заработать с нами?\n" +
                        " • Ты даешь нам деньги. Мы крутим их с помощью бота. Прибыль делим: 60% тебе, 40% нам.\n\n" +
                        "3. Это СКАМ?\n" +
                        " • Все сделки вы можете отследить и проверить через бот - @KRONOSTAT_bot\n" +
                        " • Ежедневная статистика торговли в телеграмм канале\n" +
                        " • Быстрый вывод средств\n\n" +
                        "4. Как начать торговать?\n" +
                        " • Выйти в главное меню и нажать кнопку пополнить. Все, добро пожаловать в клуб!", replyMarkup: replyKeyboardMarkupBack);
                    }

                    if (message.Text == "Пополнить 💸")
                    {
                        //await bot.SendTextMessageAsync(message.Chat, "Instruction how send me money))", replyMarkup: replyKeyboardMarkup);
                        //List<LabeledPrice> prices = new List<LabeledPrice>() { new LabeledPrice("Money", 600000) }; 
                        //await bot.SendInvoiceAsync(message.Chat.Id, "Deposit", "Deposit 100$", "НДС" , SberLogin, "RUB", prices);
                        user = "Пополнить";
                        using (var fileStream = new FileStream(depopic, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            await bot.SendPhotoAsync(
                                chatId: message.Chat.Id,
                                photo: new InputOnlineFile(fileStream)
                            );

                        }
                        using (var fileStream = new FileStream(bindepo, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            await bot.SendPhotoAsync(
                                chatId: message.Chat.Id,
                                photo: new InputOnlineFile(fileStream),
                                caption: $"USDT Tron (TRC20)\n" +
                                $"При переводе укажи свой ID: <pre language=\"c++\">{message.Chat.Id}</pre>",
                                parseMode: ParseMode.Html
                            );
                        }

                        await bot.SendTextMessageAsync(message.Chat.Id, "<pre language=\"c++\">TQNyksKjhKBcYTdWtZUgfjV1M8dj16sDUo</pre>", replyMarkup: replyKeyboardMarkupDeposit1, parseMode: ParseMode.Html);

                        //await bot.SendTextMessageAsync(message.Chat, "USDT BSC:   0x03ca462488719c919c906acc5bc81853e81e2a5c\n\n" +
                        //                                             "USDT AVAXC: 0x03ca462488719c919c906acc5bc81853e81e2a5c\n\n" +
                        //                                             "USDT BNB:   bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23 MEMO: 556476452\n\n" +
                        //                                             "USDT ETH:   0x03ca462488719c919c906acc5bc81853e81e2a5c\n\n" +
                        //                                             "USDT MATIC: 0x03ca462488719c919c906acc5bc81853e81e2a5c\n\n" +
                        //                                             "USDT TRX:   TQNyksKjhKBcYTdWtZUgfjV1M8dj16sDUo", replyMarkup: replyKeyboardMarkupDeposit1);

                    }

                    if (message.Text == "Инструкция" && user == "Пополнить")
                            
                    {
                       user = "Инструкция";
                                
                        await bot.SendTextMessageAsync(message.Chat, "Desktop или Мобильная версия?", replyMarkup: replyKeyboardMarkupDeposit2);
                            
                    }

                    if (message.Text == "Mobile" && user == "Инструкция")
                                        
                    {
                                            
                        await bot.SendTextMessageAsync(message.Chat, "Высылаю...", replyMarkup: replyKeyboardMarkupBack);
                                            
                        Instruction.Mobile(bot, message);
                                     
                    }

                    if (message.Text == "Desktop" && user == "Инструкция")
                                        
                    {
                                        
                        await bot.SendTextMessageAsync(message.Chat, "Высылаю...", replyMarkup: replyKeyboardMarkupBack);
                                         
                        Instruction.Desktop(bot, message);
                                       
                    }

                    if (message.Text == "Кошелек 💰")
                    {
                        user = "Кабинет";
                        SendImg.Wallet(message, bot, replyKeyboardMarkupCabinet);
                        
                    }

                    if (message.Text == "Баланс" && user == "Кабинет")

                    {
                        SendImg.Information(message, bot, replyKeyboardMarkupBack);
                        
                        string balance = Request.CheckingBalance(message.Chat.Id, Program.connection);
                        
                        balance = System.Text.RegularExpressions.Regex.Match(balance, "[0-9]*.[0-9][0-9]").Value;
                        
                        bot.SendTextMessageAsync(message.Chat, $"Ваш баланс: {balance} BUSD", replyMarkup: replyKeyboardMarkupCabinet).Wait();
                        
                    }

                    if (message.Text == "Вывод 🎁")
                    {
                        user = "Вывод";
                        using (var fileStream = new FileStream(withpic, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            await bot.SendPhotoAsync(
                                chatId: message.Chat.Id,
                                photo: new InputOnlineFile(fileStream)
                            );
                        }
                        await bot.SendTextMessageAsync(message.Chat, $"Выбери сеть в которой будет вывод", replyMarkup: replyKeyboardMarkupWallets);
                    }

                    if (user == "Вывод" && (message.Text == "BSC" || message.Text == "MATIC" || message.Text == "ETH" || message.Text == "AVACX" || message.Text == "TRX" || message.Text == "SOL"))
                    {
                        nameNet = message.Text;
                        await bot.SendTextMessageAsync(message.Chat, $"‼️Проверь правильность кошелька‼️\n{Request.CheckingWallets(message.Chat.Id, nameNet, Program.connection)}", replyMarkup: replyKeyboardMarkupWithdrawl1);
                    }

                    if (message.Text == "Отправить заявку" && user == "Вывод")
                    {
                        user = "Заявка";
                     
                        string balance = Request.CheckingBalance(message.Chat.Id, Program.connection);
                    
                        balance = System.Text.RegularExpressions.Regex.Match(balance, "[0-9]*.[0-9][0-9]").Value;

                        if (Request.CheckingBonus(message.Chat.Id, Program.connection) == "-1")
                        {
                            await bot.SendTextMessageAsync(message.Chat, $"Введи сумму и нажми 'Запросить'\n\nДоступно: {Convert.ToDouble(balance) - 5.0} BUSD", replyMarkup: replyKeyboardMarkupWithdrawl2);
                        }
                        else
                        {
                            await bot.SendTextMessageAsync(message.Chat, $"Введи сумму и нажми 'Запросить'\n\nДоступно: {balance} BUSD", replyMarkup: replyKeyboardMarkupWithdrawl2);
                        }

                        
                    }

                    if (message.Text == "Запросить" && user == "Заявка")
                    {
                        
                        string summ = msg[1];
                        if (Request.Withdrawl(message.Chat.Id, summ, nameNet, Program.connection, botWithdraw))
                        {
                            await bot.SendTextMessageAsync(message.Chat, $"Отправлен запрос на вывод: {msg[1]} BUSD", replyMarkup: replyKeyboardMarkupWithdrawl1);
                            //Request.Withdrawl(message.Chat.Id, summ, nameNet, Program.connection, botWithdraw);
                        }
                        else
                        {
                            user = "Вывод";
                            await bot.SendTextMessageAsync(message.Chat, $"‼️Некорректный ввод‼️", replyMarkup: replyKeyboardMarkupWithdrawl1);
                        }
                    }
                    
                    if (message.Text == "Назад")
                    {
                        await bot.SendTextMessageAsync(message.Chat, "Возвращаю в меню", replyMarkup: replyKeyboardMarkup);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        

        public static void Start()
        {
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };

            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
        }

        public static void Message(long numberTg, string message)
        {
            bot.SendTextMessageAsync(numberTg, message);
        }
    }
}
