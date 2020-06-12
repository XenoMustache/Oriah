using SFML.Graphics;
using SFML.System;
using Xenon.Common;

namespace Oriah.Objects {
	public class Chunk : GameObject {
		public Texture texture;

		byte[,] tiles = new byte[16, 16];
		Sprite[,] sprites = new Sprite[16, 16];
		FloatRect rect;
		RectangleShape rectRender;

		public void Init(Vector2f position) {
			for (var i = 0; i < 16; i++) {
				for (var j = 0; j < 16; j++) {
					var spriteRect = new IntRect();
					if (j == 0) spriteRect.Top = 0; else spriteRect.Top = 8;
					spriteRect.Left = 8 * tiles[i, j];
					spriteRect.Width = 8;
					spriteRect.Height = 8;

					sprites[i, j] = new Sprite(texture, spriteRect);
					sprites[i, j].Position = new Vector2f(position.X + i * 8, position.Y + j * 8);
				}
			}

			rect = new FloatRect(position, new Vector2f(position.X + (8 * 16), position.Y + (8 * 16)));

			rectRender = new RectangleShape(new Vector2f(rect.Width, rect.Height));
			rectRender.Position = position;
			rectRender.FillColor = Color.Transparent;
			rectRender.OutlineColor = Color.Green;
			rectRender.OutlineThickness = 0.2f;
		}

		public override void Update() { }

		public override void Render() {
			for (var i = 0; i < 16; i++) {
				for (var j = 0; j < 16; j++) {
					window.Draw(sprites[i, j]);
				}
			}
		}

		protected override void OnDispose() {
			texture.Dispose();
			rectRender.Dispose();

			foreach (var sprite in sprites) {
				sprite.Dispose();
			}
		}
	}
}
