using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TGApp
{
    class Host
    {
        private TelegramBotClient _bot;

        public Host(string token)
        {
            _bot = new TelegramBotClient(token);
        }

        public void Start()
        {
            _bot.StartReceiving(UpdateHandler, ErrorHandler);
        }

        private async Task ErrorHandler(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
        {
            Console.WriteLine($"Error: {exception.Message}");
            await Task.CompletedTask;
        }

        private async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
        {
            Console.WriteLine($"Message received: {update.Message?.Text ?? "No text"}");
            await Task.CompletedTask;
        }
    }
}
