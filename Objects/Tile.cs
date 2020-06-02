using SFML.Graphics;
using SFML.System;
using System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Tile : GameObject {
		public bool disabled = false;
		public Player player;

		RectangleShape rect;
		Vector2f position;

		public Tile(Vector2f position) {
			this.position = position;

			rect = new RectangleShape(new Vector2f(16, 16));
			rect.FillColor = Color.Red;
		}

		public override void Update() {
			//if (player != null) {
			//	float distance = (float)Math.Abs(Math.Sqrt(((player.position.X - position.X) * (player.position.X - position.X)) + ((player.position.Y - position.Y) * (player.position.Y - position.Y))));
			//	if (distance > 1) disabled = true; else disabled = false;
			//}

			if (!disabled) {
				rect.Position = position;
			}
		}

		public override void Render() {
			if (!disabled) {
				window.Draw(rect);
			}
		}
	}
}
