using Core;
using SFML.Graphics;
using SFML.System;

namespace Oriah {
	public class Oriah : Game {
		RectangleShape rect;

		public Oriah(string name) : base(name) { }

		protected override void Init() {
			rect = new RectangleShape(new Vector2f(100, 100));
			rect.Position = new Vector2f((float)window.Size.X / 2, 0);
			rect.Origin = rect.Size / 2;
			rect.FillColor = Color.Red;

			base.Init();
		}

		protected override void Input() {
		
		}

		protected override void Render() {
			window.Draw(rect);
		}

		protected override void Update(double deltaTime) {
			rect.Position += new Vector2f(0, 1 * (float)deltaTime);
		}
	}
}
