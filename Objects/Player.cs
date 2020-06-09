using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Xenon.Common;

namespace Oriah.Objects {
	public class Player : GameObject {
		public Vector2f position, camPos;

		int direction = 1;
		float moveSpeed = 0.15f, spriteSpeed = 0.15f;
		bool moving, grounded;
		Camera cam = new Camera();
		Texture texture = new Texture("Resources\\Sprites\\Player\\player_walking.png");
		Clock spriteClock = new Clock();
		Sprite sprite;
		IntRect spriteRect = new IntRect(new Vector2i(0, 0), new Vector2i(8, 16));

		public void Init(Vector2f startingPosition) {
			position = startingPosition;

			sprite = new Sprite(texture, spriteRect);
			sprite.Origin = new Vector2f(4, 8);

			cam.Init();
		}

		public override void Update() {
			var horizontal = (Keyboard.IsKeyPressed(Keyboard.Key.D) ? 1 : 0) - (Keyboard.IsKeyPressed(Keyboard.Key.A) ? 1 : 0);
			var veritcal = grounded ? 0 : 1;

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

			position += new Vector2f(moveSpeed * horizontal, 0.5f * veritcal);
			if (position.Y >= -8f) grounded = true; else grounded = false;
			sprite.Position = new Vector2f(position.X, position.Y);

			cam.target = new Vector2f(position.X, position.Y - 15);
			cam.Update();
		}

		public override void Render() {
			cam.window = window;
			cam.Render();

			window.Draw(sprite);
		}

		protected override void OnDispose() {
			cam.Dispose();
			texture.Dispose();
			sprite.Dispose();

			base.OnDispose();
		}
	}
}
