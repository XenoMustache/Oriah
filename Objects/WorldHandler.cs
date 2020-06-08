using SFML.System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class WorldHandler : GameObject {
		public Player player;
		public Vector2i size;
		Chunk chunk;

		public async Task Generate(Vector2i size) {
			this.size = size;
			List<Task> listOfTasks = new List<Task>();

			chunk = new Chunk();
			chunk.Init(new Vector2f(0, 0));

			Console.WriteLine("Generating World of size " + size.X + "x" + size.Y + "...");
			await Task.WhenAll(listOfTasks);
		}

		public override void Update() { }

		public override void Render() {
			chunk.window = window;
			chunk.Render();
		}
	}
}
