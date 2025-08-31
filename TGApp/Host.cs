using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TGApp
{
    class Host
    {
        private TelegramBotClient _bot;

        public Host(string token)
        {
            _bot = new TelegramBotClient(token);
        }
    }
}
