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

			world.Generate(new Vector2i(25, 15));
			player.Init(new Vector2f(25*4,-8));
		}

		public override void Update() {
			base.Update();
		}

		public override void Render() {
			base.Render();
		}
	}
}
