using SFML.Graphics;
using SFML.System;
using System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Chunk : GameObject {
		byte[,] tiles = new byte[16, 16];
		Sprite[,] sprites = new Sprite[16, 16];
		// TODO: Move texture object out of chunk
		Texture texture = new Texture("Resources\\tiles.png");

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

			foreach (var sprite in sprites) {
				sprite.Dispose();
			}
		}
	}
}
