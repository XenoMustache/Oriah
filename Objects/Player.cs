using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Player : GameObject {
		public Vector2f position;

		float moveSpeed = 0.25f;
		View cameraView;
		RectangleShape rect;

		public void Init(Vector2f position) {
			this.position = position;

			cameraView = new View();
			cameraView.Center = position;

			rect = new RectangleShape(new Vector2f(8, 16));
			rect.Origin = rect.Size / 2;
			rect.FillColor = Color.Blue;
		}

		public override void Update() {
			var horizontal = (Keyboard.IsKeyPressed(Keyboard.Key.D) ? 1 : 0) - (Keyboard.IsKeyPressed(Keyboard.Key.A) ? 1 : 0);

			var oldConverted = new Vector2f((float)Math.Floor(position.X / 8), (float)Math.Floor(position.Y / 8));

			position += new Vector2f(moveSpeed * horizontal, 0);
			rect.Position = position;
			
			var newConverted = new Vector2f((float)Math.Floor(position.X / 8), (float)Math.Floor(position.Y / 8));

			if (horizontal != 0 && newConverted != oldConverted) Console.WriteLine(newConverted.ToString());

			cameraView.Center = position;
			window.SetView(cameraView);

			base.Update();
		}

		public override void Render() {
			window.Draw(rect);

			cameraView.Size = (Vector2f)window.Size;
			cameraView.Zoom(0.3f);

			base.Render();
		}
	}
}
