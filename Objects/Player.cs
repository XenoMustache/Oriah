using Oriah.Components;
using SFML.Graphics;
using SFML.System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Player : GameObject {
		RectangleShape rect;
		Camera camera = new Camera();
		Vector2f position;

		public void Init(Vector2f position) {
			this.position = position;

			components.Add(camera);

			rect = new RectangleShape(new Vector2f(100, 100));
			rect.Origin = rect.Size / 2;
			rect.FillColor = Color.Blue;
		}

		public override void Update(double deltaTime) {
			//position += new Vector2f(0, 10 * (float)deltaTime);
			rect.Position = position;

			base.Update(deltaTime);
		}

		public override void Render(RenderWindow window) {
			window.Draw(rect);

			camera.center = position;
			camera.size = (Vector2f)window.Size;

			base.Render(window);
		}
	}
}
