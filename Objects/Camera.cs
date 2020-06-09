using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using Xenon.Common.Object;

namespace Oriah.Objects {
	public class Camera : GameObject {
		public Vector2f target;

		float camZoom = 0.2f;
		View cameraView, uiView;
		Font font = new Font("Resources\\Fonts\\arial.ttf");
		Text hudText;

		public void Init() {
			var x = (float)Math.Floor(target.X);
			var y = (float)Math.Floor(target.Y + 15);

			hudText = new Text($"X: {x}, Y: {y}", font, 25);
			hudText.Scale = new Vector2f(0.5f, 0.5f);
			hudText.FillColor = Color.White;

			cameraView = new View();
			uiView = new View();
		}

		public override void Update() {
			var zoom = (Keyboard.IsKeyPressed(Keyboard.Key.Hyphen) ? 1 : 0) - (Keyboard.IsKeyPressed(Keyboard.Key.Equal) ? 1 : 0);

			camZoom += zoom * 0.001f;
			camZoom = Math.Clamp(camZoom, 0.1f, 0.28f);

			if (Keyboard.IsKeyPressed(Keyboard.Key.Backspace)) camZoom = 0.2f;

			cameraView.Center = new Vector2f(target.X, target.Y);

			var x = (float)Math.Floor(target.X);
			var y = (float)Math.Floor(target.Y + 15);
			hudText.DisplayedString = $"X: {x}, Y: {y}";
		}

		public override void Render() {
			window.SetView(uiView);
			uiView.Size = new Vector2f(1000, 500);
			window.Draw(hudText);
			hudText.Position = window.MapPixelToCoords(new Vector2i(0, 0));

			window.SetView(cameraView);
			cameraView.Size = (Vector2f)window.Size;
			cameraView.Zoom(camZoom);
		}
	}
}
