
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

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

			Display.Append("Rubycord", "Guild detected: " + e.Guild.Name);

			if (!Cache.guilds.Contains(e.Guild))
				Cache.guilds.Add(e.Guild);

			foreach (var user in e.Guild.GetAllMembersAsync().Result)
				if (Array.Find(Cache.users.ToArray(), c => c.Id == user.Id) == null)
					Cache.users.Add(user);

			return Task.CompletedTask;
		}

		public static Task OnClientErrored (ClientErrorEventArgs e) {

			Display.Append("Rubycord", e.Exception.Message);

			return Task.CompletedTask;
		}

		public static Task OnMessageCreated (MessageCreateEventArgs e) {

			if (!Cache.messages.ContainsKey(e.Channel.Id))
				Cache.messages.Add(e.Channel.Id, new List<string>());

			Cache.messages[e.Channel.Id].Add("["+e.Message.Author.Username+"]: "+e.Message.Content);

			return Task.CompletedTask;
		}
	}
}
