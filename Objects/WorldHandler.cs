using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xenon.Common;

namespace Oriah.Objects {
	public class WorldHandler : GameObject {
		public int size;
		public Player player;

		List<Chunk> chunks = new List<Chunk>();
		Texture ts_outdoors = new Texture("Resources\\Sprites\\Tilesets\\outdoors.png");

		public async Task Generate(int size) {
			this.size = size;
			List<Task> listOfTasks = new List<Task>();

			for (var i = 0; i < size; i++) {
				Chunk chunk = new Chunk();
				chunk.texture = ts_outdoors;
				chunk.Init(new Vector2f(i * 128, 0));

				chunks.Add(chunk);
			}

			await Task.WhenAll(listOfTasks);
		}

		public override void Update() { }

		public override void Render() {
			foreach (var chunk in chunks) {
				chunk.window = window;
				chunk.Render();
			}
		}
	}
}
