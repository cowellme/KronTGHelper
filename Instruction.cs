using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace KronTGHelper
{
    public class Instruction
    {
        static ReplyKeyboardMarkup replyKeyboardMarkupBack = new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Назад" } }) { ResizeKeyboard = true };

        public static async void Desktop(ITelegramBotClient bot, Message message)
        {
            string step1 = Environment.CurrentDirectory + @$"\InstrucPic\1step.png";

            using (var fileStream = new FileStream(step1, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream),
                    caption: "1. Нажми на кнопку Вывод"
                );
            }

            string step2 = Environment.CurrentDirectory + @$"\InstrucPic\2step.png";

            using (var fileStream = new FileStream(step2, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream),
                    caption: "2. Нажми на кнопку Вывод криптовалюты"
                );
            }

            string step3 = Environment.CurrentDirectory + @$"\InstrucPic\3step.png";

            using (var fileStream = new FileStream(step3, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream),
                    caption: "3. Нажми как на картинке\n ID 19010392"
                );
            }

            string step4 = Environment.CurrentDirectory + @$"\InstrucPic\4step.png";

            using (var fileStream = new FileStream(step4, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream),
                    caption: "4. Нажми как на картинке\n\n5. кнопку 'Отправить'\n\n Всё ты успешно пополнил свой счёт!"
                );
            }
        }

        public static async void Mobile(ITelegramBotClient bot, Message message)
        {
            string stepAll = Environment.CurrentDirectory +  @$"\InstrucPic\all.png";

            using (var fileStream = new FileStream(stepAll, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await bot.SendPhotoAsync(
                    chatId: message.Chat.Id,
                    photo: new InputOnlineFile(fileStream),
                    caption: "1. Нажми на кошелёк\n\n2. Выбери 'Спотовую' версию\n\n3. Выбери USDT валюту\n\n4. Нажми кнопку 'Вывод'\n\n5. Отправить по...\n\n6. В 6-ое поле введи: 19010392\n\n7.Сумма перевода\n\n8. В коментрарии укажи свой ник Telegram\n  Пример: @nickname\n\n9. Нажми отправить"
                );
            }
        }
    }
}
