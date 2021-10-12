
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Rubycord {

	public static class Discord {

		public static void Start () {

			shouldStop = false;
			running = true;

			Discord.LoopAsync().ConfigureAwait(false);

			running = false;
		}
		public static void Stop () {

			shouldStop = true;
		}

		public static bool running;

		private static bool shouldStop;

		private static DiscordClient discord;

		private static async Task LoopAsync () {

			Display.Append("Rubycord", "Configuring...");

			discord = new DiscordClient(new DiscordConfiguration{

					Token = Config.Token,
					TokenType = Config.BotUser ? TokenType.Bot : TokenType.User,
					AutoReconnect = true
			});

			discord.Ready += Event.OnReady;
			discord.GuildAvailable += Event.OnGuildAvailable;
			discord.ClientErrored += Event.OnClientErrored;
			discord.MessageCreated += Event.OnMessageCreated;

			Display.Append("Rubycord", "Connecting to Discord...");

			await discord.ConnectAsync();

			while (!shouldStop) {

				await Task.Delay(512);
			}

			Display.Append("Rubycord", "Disconnecting from Discord...");

			await discord.DisconnectAsync();

			Display.Append("Rubycord", "Disconnected successfully...");
		}
	}
}
