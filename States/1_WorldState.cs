using Oriah.Objects;
using SFML.Graphics;
using System;
using Xenon.Common.State;

namespace Oriah.States {
	public class _1_WorldState : GameState {
		WorldHandler world = new WorldHandler();
		Player player = new Player();

		public override void Load() {
			base.Load();

			Objects.Add(world);
			Objects.Add(player);

			world.Generate();
			player.Init(new SFML.System.Vector2f(1280 / 2, 720 / 2));
		}

		public override void Update(double deltaTime) {
			base.Update(deltaTime);
		}

		public override void Render(RenderWindow window) {
			base.Render(window);
		}
	}
}
