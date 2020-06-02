using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Player : GameObject {
		public Vector2f position;

		float moveSpeed = 0.5f;
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
			var left = Keyboard.IsKeyPressed(Keyboard.Key.A) ? 1 : 0;
			var right = Keyboard.IsKeyPressed(Keyboard.Key.D) ? 1 : 0; ;
			var up = Keyboard.IsKeyPressed(Keyboard.Key.W) ? 1 : 0; ;
			var down = Keyboard.IsKeyPressed(Keyboard.Key.S) ? 1 : 0; ;

			var horizontal = right - left;
			var vertical = down - up;

			position += new Vector2f(moveSpeed * horizontal, moveSpeed * vertical);
			rect.Position = position;

			cameraView.Move(new Vector2f(moveSpeed * horizontal, moveSpeed * vertical));
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
