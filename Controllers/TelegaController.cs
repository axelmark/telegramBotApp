using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramBotApp.Models;

namespace telegaBot2.Controllers
{
    public class TelegaController : ApiController
    {
		public static List<string> log = new List<string>();


		[Route(@"api/bot/exec")]
		public async Task<OkResult> Do([FromBody]Update update)
		{
			try
			{
				log.Add($"{DateTime.Now}: EnterDo");
				if (update != null)
				{
					var commands = Bot.Commands;
					var messages = update.Message;
					var client = await Bot.Get();

					foreach (var cmd in commands)
					{
						if (cmd.Contains(messages.Text))
						{
							log.Add($"{DateTime.Now}: EnterDo commont found " + messages.Text);
							await cmd.executeAsync(messages, client);
							break;
						}
					}
					log.Add($"{DateTime.Now}: EnterDo finishinggg");
				}
				log.Add($"{DateTime.Now}: EnterDo exit");
			}
			catch (Exception ex)
			{
				log.Add($"{DateTime.Now}: Task<OkResult> Do() Exception {ex}");
			}
			return Ok();
		}
	}
}
