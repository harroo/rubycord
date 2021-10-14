
namespace Rubycord {

	public static class Command {

		public static void Feed (string input) {

			string[] args = input.Contains(' ') ? input.Split(' ') : new string[]{input};

			switch (args[0]) {

				case "/exit": Discord.Stop(); break;

				case "/list": case "/guilds": case "/ls": Display.ListGuilds(); break;

				default: Display.Append("Rubycord::Command", "Unknown Command! '"+input+"'"); break;
			}
		}
	}
}
