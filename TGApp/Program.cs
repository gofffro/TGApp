using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using DotNetEnv;

Env.Load();
var token = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN");
using var cts = new CancellationTokenSource();
var bot = new TelegramBotClient(token);
var me = await bot.GetMe();
bot.OnMessage += OnMessage;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel(); 

// method that handle messages received by the bot:
async Task OnMessage(Message msg, UpdateType type)
{
    if (msg.Text == "/start")
    {
        await bot.SendMessage(msg.Chat, "bot");
    }
}