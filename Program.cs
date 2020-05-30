using SFML.System;
using Xenon.Common.Utilities;

namespace Oriah {
	class Program {
		static void Main(string[] args) {
			MiscUtils.HideConsole();
			new Oriah("Oriah", new Vector2u(1280, 720));
		}
	}
}
