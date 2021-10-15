
using System;
using System.Collections.Generic;
using System.Threading;

namespace Rubycord {

	public static class Display {

		private static Mutex mutex = new Mutex();

		private static List<string> defaultList = new List<string>();
		private static List<string> messageList {

			get {
				if (Cache.currentChannel == null) return defaultList;	
				if (Cache.messages.ContainsKey(Cache.currentChannel.Id))
					return Cache.messages[Cache.currentChannel.Id];
				else return defaultList;
			}

			set {
				defaultList = value;
				if (Cache.currentChannel != null)
					if (Cache.messages.ContainsKey(Cache.currentChannel.Id))
						Cache.messages[Cache.currentChannel.Id] = value; 
			}
		}

		public static void Append (string sender, string message) { mutex.WaitOne(); try {

			defaultList.Add("[" + sender + "]: " + message);

			foreach (var list in Cache.messages.Values) 
				list.Add("[" + sender + "]: " + message);

		} finally { mutex.ReleaseMutex(); } }

		public static void Append (string message) { mutex.WaitOne(); try {

			defaultList.Add(message);

			foreach (var list in Cache.messages.Values)
				list.Add(message);

		} finally { mutex.ReleaseMutex(); } }

		public static void ListGuilds () {

			Append("Showing all text channels:");

			foreach (var guild in Cache.guilds) {

				Append("    " + guild.Name);

				foreach (var channel in guild.Channels) {

					if (channel.Type != DSharpPlus.ChannelType.Text) continue;

					Append(Cache.GetIndex(channel.Id).ToString() + ": " + guild.Name + "::" + channel.Name);
				}
			}

			Append("Showing all DM channels:");

			foreach (var user in Cache.users) {

				Append(Cache.GetIndex(user.Id).ToString() + ": " + user.Username + "#" + user.Discriminator);
			}
		}

		public static void Tick () {

			RunChecks();
		}

		private static int messageListCache;
		private static int consoleHeightCache, consoleWidthCache;
		private static string inputCache;

		private static void RunChecks () { mutex.WaitOne(); try {

			if (messageListCache != messageList.Count) {

				messageListCache = messageList.Count;
				Render();
			}

			if (consoleHeightCache != Console.BufferHeight) {

				consoleHeightCache = Console.BufferHeight;
				Render();
			}

			if (consoleWidthCache != Console.BufferWidth) {

				consoleWidthCache = Console.BufferWidth;
				Render();
			}

			if (inputCache != Input.inputValue) {

				inputCache = Input.inputValue;
				Render();
			}

		} finally { mutex.ReleaseMutex(); } }

		private static void Render () {

			Console.Clear();

			foreach (string message in messageList)
				Console.WriteLine(message);

			if (messageList.Count < Console.BufferHeight)
				for (int i = 2; i < Console.BufferHeight - messageList.Count; ++i)
					Console.WriteLine();

			for (int i = 0; i < Console.BufferWidth; ++i)
				Console.Write("─");

			Console.Write(">: " + inputCache);
		}
	}
}
