using SFML.Graphics;
using SFML.System;
using System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class WorldHandler : GameObject {
		int worldSize;
		Tile tile;

		public void Generate(int size = 25) {
			worldSize = size;

			Console.WriteLine("Generating World...");

			tile = new Tile(new Vector2f(100, 100));
		}

		public override void Update(double deltaTime) {
			tile.Update(deltaTime);
		}

		public override void Render(RenderWindow window) {
			tile.Render(window);
		}
	}
}
