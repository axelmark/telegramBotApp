using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading.Tasks;

namespace TelegramBotApp.Models.Commands
{
	public abstract class Command
	{
		public abstract string Name { get; }
		public virtual async Task executeAsync(Message message, TelegramBotClient client)
		{
			await Task.Delay(1);
		}

		public bool Contains(string command)
		{
			return command.StartsWith("/"+this.Name);
		}

	}
}