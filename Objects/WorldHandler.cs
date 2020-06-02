using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class WorldHandler : GameObject {
		List<Tile> tiles = new List<Tile>();

		public void Generate(Vector2i size) {
			for (var i = 0; i < size.X; i++) {
				for (var j = 0; j < size.Y; j++) {
					Tile tile = new Tile(new Vector2f(i * 8, j * 8));

					tiles.Add(tile);
				}
			}

			Console.WriteLine("Generating World...");
		}

		public override void Update() {
			for (var i = 0; i < tiles.Count; i++) {
				tiles[i].deltaTime = deltaTime;
				tiles[i].Update();
			}
		}

		public override void Render() {
			for (var i = 0; i < tiles.Count; i++) {
				tiles[i].window = window;
				tiles[i].Render();
			}
		}
	}
}
