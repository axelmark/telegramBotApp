using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace telegaBot2.Controllers
{
	public class HomeController : Controller
	{
		public string Index()
		{
			return "telegram bots: <br/>" + string.Join("<br/>", TelegaController.log);
		}

	}
}


