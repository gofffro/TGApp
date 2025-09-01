using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TGApp
{
    class Host
    {
        public Action<ITelegramBotClient, Update>? OnMessage;
        private TelegramBotClient _bot;

        public Host(string token)
        {
            _bot = new TelegramBotClient(token);
        }

        public void Start()
        {
            _bot.StartReceiving(UpdateHandler, ErrorHandler);
            Console.WriteLine("Bot started.");
        }

        private async Task ErrorHandler(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
        {
            Console.WriteLine($"Error: {exception.Message}");
            await Task.CompletedTask;
        }

        private async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
        {
            Console.WriteLine($"Message received: {update.Message?.Text ?? "No text"}");
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                    {
                            OnMessage?.Invoke(client, update);
                            return;
                    }
                    case UpdateType.CallbackQuery:
                    {
                            var callbackQuery = update.CallbackQuery;
                            var user = callbackQuery.From;
                            var chat = callbackQuery.Message.Chat;
                            Console.WriteLine($"{user.Username} ({user.Id}) clicked on {callbackQuery.Data}");
                            switch (callbackQuery.Data)
                            {
                                case "chooseTyres":
                                {
                                        await client.AnswerCallbackQuery(callbackQuery.Id);
                                        await client.SendMessage(chat.Id, "Вы выбрали шины!");
                                        return;            
                                }
                                case "chooseDisks":
                                {
                                        await client.AnswerCallbackQuery(callbackQuery.Id);
                                        await client.SendMessage(chat.Id, "Вы выбрали диски!");
                                        return;            
                                }
                                case "chooseWheels":
                                {
                                        await client.AnswerCallbackQuery(callbackQuery.Id);
                                        await client.SendMessage(chat.Id, "Вы выбрали колеса!");
                                        return;            
                                }
                            }

                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await Task.CompletedTask;
        }
    }
}
