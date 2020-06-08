using SFML.System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class WorldHandler : GameObject {
		public int size;
		Chunk chunk;

		public async Task Generate(int size) {
			this.size = size;
			List<Task> listOfTasks = new List<Task>();

			chunk = new Chunk();
			chunk.Init(new Vector2f(0, 0));

			await Task.WhenAll(listOfTasks);
		}

		public override void Update() { }

		public override void Render() {
			chunk.window = window;
			chunk.Render();
		}
	}
}
