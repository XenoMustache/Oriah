using Oriah.Objects;
using SFML.Graphics;
using System;
using Xenon.Common.State;

namespace Oriah.States {
	public class _1_WorldState : GameState {
		WorldHandler world = new WorldHandler();

		public override void Load() {
			base.Load();

			objectManager.AddObject(world);

			world.Generate();
		}

		public override void Update(double deltaTime) {
			base.Update(deltaTime);
		}

		public override void Render(RenderWindow window) {
			base.Render(window);
		}
	}
}
