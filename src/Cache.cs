
using System;
using System.Collections.Generic;

using DSharpPlus;
using DSharpPlus.Entities;

namespace Rubycord {

	public static class Cache {

		public static DiscordChannel currentChannel;

		public static List<DiscordGuild> guilds = new List<DiscordGuild>();

		public static List<string> queuedMessages = new List<string>();

		public static Dictionary<ulong, List<string>> messages = new Dictionary<ulong, List<string>>();

		public static void SetChannel (int index) {

			int hunter = 0;

			foreach (var guild in guilds) 
				foreach (var channel in guild.Channels) {

					if (hunter == index) {

						currentChannel = channel;

						if (!messages.ContainsKey(channel.Id))
							messages.Add(channel.Id, new List<string>());

						return;
					}
					hunter++;
				}
		}

		public static int GetIndex (ulong channelId) {

			int index = 0;

			foreach(var guild in guilds)
				foreach (var channel in guild.Channels) {

					if (channel.Id == channelId)
						return index;
					else
						index++;
				}

			return 0;
		}
	}
}
