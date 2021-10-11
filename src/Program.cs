
using System;

namespace Rubycord {

	public static class Program {

		public static void Main (string[] args) {

			Input.Start();
			//discord.start
			//discord will take control of evry thing and call the display checks
			//for now temp:
			while (true) Display.Tick();
			Input.Stop();
		}
	}
}
