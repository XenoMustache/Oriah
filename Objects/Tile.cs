using SFML.Graphics;
using SFML.System;
using System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Tile : GameObject {
		RectangleShape rect;
		Vector2f position;

		public Tile(Vector2f position) {
			this.position = position;

			rect = new RectangleShape(new Vector2f(16, 16));
			rect.FillColor = Color.Red;
			rect.Position = position;
			rect.Origin = rect.Size / 2; 
		}

		public override void Update(double deltaTime) {
			base.Update(deltaTime);
		}

		public override void Render(RenderWindow window) {
			window.Draw(rect);

			base.Render(window);
		}
	}
}
