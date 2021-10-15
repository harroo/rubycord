
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

		public static List<DiscordMember> users = new List<DiscordMember>();

		public static void SetChannel (int index) {

			int hunter = 0;

			foreach (var guild in guilds) 
				foreach (var channel in guild.Channels) {

					if (channel.Type != ChannelType.Text) continue;

					if (hunter == index) {

						currentChannel = channel;

						if (!messages.ContainsKey(channel.Id))
							messages.Add(channel.Id, new List<string>());

						return;
					}
					hunter++;
				}

			foreach (var user in users) {

				if (hunter == index) {

					currentChannel = user.CreateDmChannelAsync().Result;

					if (!messages.ContainsKey(currentChannel.Id))
						messages.Add(currentChannel.Id, new List<string>());

					return;
				}
				hunter++;
			}
		}

		public static int GetIndex (ulong channelId) {

			int index = 0;

			foreach (var guild in guilds)
				foreach (var channel in guild.Channels) {

					if (channel.Type != ChannelType.Text) continue;

					if (channel.Id == channelId)
						return index;
					else
						index++;
				}

			foreach (var user in users) {

				if (user.Id == channelId)
					return index;
				else 
					index++;
			}

			return 0;
		}
	}
}
