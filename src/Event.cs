
using System.Threading;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace Rubycord {

	public static class Event {

		public static Task OnReady (ReadyEventArgs e) {

			Display.Append("Rubycord", "Successfully connected to Discord!");

			return Task.CompletedTask;
		}

		public static Task OnGuildAvailable (GuildCreateEventArgs e) {

			//Discord.CacheGuild(e.Guild);
			//change to a cache controller class

			return Task.CompletedTask;
		}

		public static Task OnClientErrored (ClientErrorEventArgs e) {

			Display.Append("Rubycord", e.Exception.Message);

			return Task.CompletedTask;
		}

		public static Task OnMessageCreated (MessageCreateEventArgs e) {

			Display.Append(e.Message.Author.Username, e.Message.Content);

			return Task.CompletedTask;
		}
	}
}
