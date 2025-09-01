using TGApp;
using DotNetEnv;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

internal class Program
{
    static void Main()
    {
        Env.Load();
        var token = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN");

        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("TELEGRAM_TOKEN is not set in the environment variables.");
            return;
        }

        Host bot = new Host(token);
        bot.Start();
        bot.OnMessage += OnMessage;
        

        
        Console.ReadLine();
    }

    private static async void OnMessage(ITelegramBotClient client, Update update)
    {
        if (update.Message?.Text?.ToLower() == "/start")
        {
            var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton.WithCallbackData("Шины", "chooseTyres"),
                        InlineKeyboardButton.WithCallbackData("Диски", "chooseDisks"),
                        InlineKeyboardButton.WithCallbackData("Колеса", "chooseWheels")
                    }
                });
            await client.SendMessage(update.Message.Chat.Id, "Выберите категорию: ", replyMarkup: inlineKeyboard);
            return; // Выход из метода
        }
    }
}