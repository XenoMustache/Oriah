using SFML.System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class WorldHandler : GameObject {
		public Player player;
		List<Tile> tiles = new List<Tile>();

		public async Task Generate(Vector2i size) {
			List<Task> listOfTasks = new List<Task>();

			for (var i = 0; i < size.X; i++) {
				for (var j = 0; j < size.Y; j++) {
					listOfTasks.Add(CreateTile(i, j));
				}
			}

			Console.WriteLine("Generating World of size " + size.X + "x" + size.Y + "...");
			await Task.WhenAll(listOfTasks);
		}

		public Task CreateTile(int i, int j) {
			Tile tile = new Tile();
			tile.Init(new Vector2f(i * 8, j * 8));

			tile.player = player;
			tiles.Add(tile);

			return Task.CompletedTask;
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
