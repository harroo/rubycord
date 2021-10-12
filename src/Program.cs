
using System;

namespace Rubycord {

	public static class Program {

		public static void Main (string[] args) {

			Input.Start();
			Discord.Start();
			
			while (Discord.running) {

				Display.Tick();
			}

			Input.Stop();
		}
	}
}
