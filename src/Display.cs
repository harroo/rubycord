
using System;
using System.Collections.Generic;

namespace Rubycord {

	public static class Display {

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

		public static void Append (string sender, string message) {

			defaultList.Add("[" + sender + "]: " + message);

			foreach (var list in Cache.messages.Values) 
				list.Add("[" + sender + "]: " + message);
		}
		public static void Append (string message) {

			defaultList.Add(message);

			foreach (var list in Cache.messages.Values)
				list.Add(message);
		}

		public static void ListGuilds () {

			foreach (var guild in Cache.guilds) {

				Append(guild.Name);

				foreach (var channel in guild.Channels) {

					Append(channel.Name);
				}
			}
		}

		public static void Tick () {

			RunChecks();
		}

		private static int messageListCache;
		private static int consoleHeightCache, consoleWidthCache;
		private static string inputCache;

		private static void RunChecks () {

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
		}

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
