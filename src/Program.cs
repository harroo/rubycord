
using System;
using System.Threading;

namespace Rubycord {

	public static class Program {

		public static void Main (string[] args) {

			if (!Config.LoadConfig()) {

				Console.WriteLine("Failed to Config file,");
				Console.WriteLine("'.rubyconf' has been generated!");

				return;
			}

			Input.Start();
			Discord.Start();
			
			while (Discord.running) {

				Display.Tick();

				Thread.Sleep(10);
			}

			Input.Stop();
		}
	}
}
