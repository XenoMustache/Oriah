using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using Xenon.Client;
using Xenon.Common;

namespace Oriah.Objects {
	public class Player : GameObject {
		public Vector2f position, camPos;
		public List<Chunk> chunks;

		int direction = 1;
		float moveSpeed = 0.15f, spriteSpeed = 0.15f;
		bool moving, grounded;
		Camera cam = new Camera();
		Texture texture = new Texture("Resources\\Sprites\\Player\\player_walking.png");
		Clock spriteClock = new Clock();
		Sprite sprite;
		IntRect spriteRect = new IntRect(new Vector2i(0, 0), new Vector2i(8, 16));
		FloatRect cullrect = new FloatRect();

		public void Init(Vector2f startingPosition) {
			position = startingPosition;

			sprite = new Sprite(texture, spriteRect);
			sprite.Origin = new Vector2f(4, 8);

			cam.Init();
		}

		public override void Update() {
			var jump = Input.GetKeyDown(Keyboard.Key.Space, true);
			var horizontal = Input.GetKey(Keyboard.Key.D) - Input.GetKey(Keyboard.Key.A);
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

			foreach (var chunk in chunks)
				if (!chunk.rect.Intersects(cullrect)) chunk.disabled = false; else chunk.disabled = true;

			cam.target = new Vector2f(position.X, position.Y - 15);
			cam.Update();
		}

		public override void Render() {
			cam.window = window;
			cam.Render();

			cullrect.Left = window.MapPixelToCoords(new Vector2i(0, 0)).X;
			cullrect.Top = window.MapPixelToCoords(new Vector2i(0, 0)).Y;

			cullrect.Width = window.MapPixelToCoords((Vector2i)window.Size).X;
			cullrect.Height = window.MapPixelToCoords((Vector2i)window.Size).Y;

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
