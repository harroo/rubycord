
using System;
using System.IO;

namespace Rubycord {

	public static class Config {

		public static string Token;

		public static bool BotUser;

		private static string configPath = ".rubyconf";

		public static bool LoadConfig () {

			if (!File.Exists(configPath)) {

				File.WriteAllText(configPath, "Token:\nIsBot:true");

				return false;
				
			} else {

				string[] values = File.ReadAllLines(configPath);

				Token = values[0].Split(':')[1];
				BotUser = values[1].Split(':')[1] == "true";

				return true;
			}
		}
	}
}
