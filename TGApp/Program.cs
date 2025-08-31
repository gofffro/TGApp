using TGApp;
using DotNetEnv;

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
        Console.ReadLine();
    }
}