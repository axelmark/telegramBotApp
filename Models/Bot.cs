using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using telegaBot2.Controllers;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.Commands;

namespace TelegramBotApp.Models
{
	public static class Bot
	{
		private static TelegramBotClient client;
		private static List<Command> commandsList;
		public static IList<Command> Commands { get => commandsList; }

		public static async Task<TelegramBotClient> Get()
		{
			if (client != null)
			{
				return client;
			}
			try
			{
				TelegaController.log.Add($"{DateTime.Now}: Task<TelegramBotClient> Get() entering to create");

				commandsList = new List<Command>();
				commandsList.Add(new HelloComand());

				client = new TelegramBotClient(AppSettings.Key);
				client.OnReceiveError += Client_OnReceiveError;
				client.OnReceiveGeneralError += Client_OnReceiveGeneralError;
				await client.SetWebhookAsync(String.Format(AppSettings.Url, "api/bot/exec"));
				TelegaController.log.Add($"{DateTime.Now}: Task<TelegramBotClient> Get() exit create");

				return client;
			}
			catch (Exception ex)
			{

				TelegaController.log.Add($"{DateTime.Now}: Task<TelegramBotClient> Get() Exception {ex}");
				return null;
			}
		}

		private static void Client_OnReceiveGeneralError(object sender, Telegram.Bot.Args.ReceiveGeneralErrorEventArgs e)
		{
			TelegaController.log.Add($"{DateTime.Now}: OnReceiveGeneralError {e.Exception}");
		}

		private static void Client_OnReceiveError(object sender, Telegram.Bot.Args.ReceiveErrorEventArgs e)
		{
			TelegaController.log.Add($"{DateTime.Now}: OnReceiveError {e.ApiRequestException}");

		}
	}
}