
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
	}
}
