using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotApp.Models.Commands
{
	public class HelloComand : Command
	{
		public override string Name => "hello";


		public override async Task executeAsync(Message message, TelegramBotClient client)
		{
			var chatId = message.Chat.Id;
			var messageId = message.MessageId;

			await client.SendTextMessageAsync(chatId, "И вам здрасти) ", replyToMessageId: messageId);
		}
	}
}