
using System;

namespace Rubycord {

	public static class Command {

		public static void Feed (string input) {

			string[] args = input.Contains(' ') ? input.Split(' ') : new string[]{input};

			switch (args[0]) {

				case "/exit": Discord.Stop(); break;

				case "/list": case "/guilds": case "/ls": Display.ListGuilds(); break;

				case "/switch": case "/channel": case "/mv": Cache.SetChannel(Convert.ToInt32(args[1])); break;

				default: Display.Append("Rubycord::Command", "Unknown Command! '" + input + "'"); break;
			}
		}
	}
}
