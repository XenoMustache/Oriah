using Oriah.Components;
using SFML.Graphics;
using SFML.System;
using System;
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

			camera.size = new Vector2f(1280, 720);
		}

		public override void Update(double deltaTime) {
			position += new Vector2f(0, 100 * (float)deltaTime);
			rect.Position = position;

			camera.center = this.position;

			Console.WriteLine("Player update");
			Console.WriteLine(position.X + " " + position.Y);

			base.Update(deltaTime);
		}

		public override void Render(RenderWindow window) {
			window.Draw(rect);
			base.Render(window);
		}
	}
}
