using Oriah.Objects;
using SFML.System;
using Xenon.Common.State;

namespace Oriah.States {
	public class _1_WorldState : GameState {
		WorldHandler world = new WorldHandler();
		Player player = new Player();

		public override void Init() {
			base.Init();

			Objects.Add(world);
			Objects.Add(player);

			world.Generate(new Vector2i(25, 25));
			player.Init(new Vector2f(1280 / 2, 720 / 2));
		}

		public override void Update() {
			base.Update();
		}

		public override void Render() {
			base.Render();
		}
	}
}
