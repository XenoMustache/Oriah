using Oriah.States;
using SFML.Graphics;
using SFML.System;
using Xenon.Client;

namespace Oriah {
	public class Oriah : Game {
		public Oriah(string name, Vector2u screenSize) : base(name, screenSize) { }

		protected override void Init() {
			stateManager.AddState(new _1_WorldState(), 1);
			stateManager.Goto(1, false, true);

			base.Init();
		}

		protected override void Update(double deltaTime) {
			base.Update(deltaTime);
		}

		protected override void Render(RenderWindow window) {
			base.Render(window);
		}
	}
}
