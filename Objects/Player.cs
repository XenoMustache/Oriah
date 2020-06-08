using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Player : GameObject {
		public Vector2f position;
		public int direction = 1;

		float moveSpeed = 0.15f, spriteSpeed = 0.15f, camZoom = 0.3f;
		bool moving;
		Texture texture = new Texture("Resources\\walking.png");
		Clock spriteClock = new Clock();
		View cameraView;
		RectangleShape rect;
		Sprite sprite;
		IntRect spriteRect = new IntRect(new Vector2i(0, 0), new Vector2i(8, 16));
		Font font = new Font("Resources\\arial.ttf");
		Text positionText;

		public void Init(Vector2f startingPosition) {
			position = startingPosition;
			sprite = new Sprite(texture, spriteRect);
			sprite.Origin = new Vector2f(4, 8);
			positionText = new Text( "X: " + (float)Math.Floor(position.X) + " Y: " + (float)Math.Floor(position.Y), font, 50);
			positionText.Scale = new Vector2f(0.15f, 0.15f);
			positionText.FillColor = Color.White;

			rect = new RectangleShape(new Vector2f(8, 16));
			rect.Origin = rect.Size / 2;
			rect.FillColor = Color.Blue;

			cameraView = new View();
			cameraView.Center = new Vector2f(position.X, position.Y - 30);
		}

		public override void Update() {
			var horizontal = (Keyboard.IsKeyPressed(Keyboard.Key.D) ? 1 : 0) - (Keyboard.IsKeyPressed(Keyboard.Key.A) ? 1 : 0);
			var zoom = (Keyboard.IsKeyPressed(Keyboard.Key.Hyphen) ? 1 : 0) - (Keyboard.IsKeyPressed(Keyboard.Key.Equal) ? 1 : 0);
			var oldConverted = new Vector2f((float)Math.Floor(position.X), (float)Math.Floor(position.Y));

			camZoom += zoom * 0.001f;
			camZoom = Math.Clamp(camZoom, 0.2f, 0.35f);

			if (Keyboard.IsKeyPressed(Keyboard.Key.Backspace)) camZoom = 0.3f;

			if (horizontal != 0) {
				moving = true;
				direction = horizontal;
			} else
				moving = false;

			if (spriteClock.ElapsedTime.AsSeconds() > spriteSpeed) {
				if (moving) {
					if (spriteRect.Left == 24)
						spriteRect.Left = 0;
					else
						spriteRect.Left += 8;
				} else
					spriteRect.Left = 24;

				sprite.TextureRect = spriteRect;
				spriteClock.Restart();
			}

			sprite.Scale = new Vector2f(1 * direction, 1);

			position += new Vector2f(moveSpeed * horizontal, 0);
			sprite.Position = new Vector2f(position.X, position.Y);
			rect.Position = position;
			positionText.Position = new Vector2f(position.X - 190, position.Y - 155);

			var newConverted = new Vector2f((float)Math.Floor(position.X), (float)Math.Floor(position.Y));

			if (horizontal != 0 && newConverted != oldConverted) positionText.DisplayedString = "X: " + newConverted.X + " Y: " + newConverted.Y;
			cameraView.Center = new Vector2f(position.X, position.Y - 50);
			window.SetView(cameraView);
		}

		public override void Render() {
			// window.Draw(rect);
			window.Draw(sprite);
			window.Draw(positionText);

			cameraView.Size = (Vector2f)window.Size;
			cameraView.Zoom(camZoom);
		}

		protected override void OnDispose() {
			rect.Dispose();
			texture.Dispose();
			sprite.Dispose();

			base.OnDispose();
		}
	}
}
