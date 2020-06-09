using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using Xenon.Common.Utilities;
using Xenon.Common;
using Xenon.Client;

namespace Oriah.Objects {
	public class Camera : GameObject {
		public Vector2f target;

		float camZoom = 0.2f;
		FPS fps = new FPS();
		Font font = new Font("Resources\\Fonts\\arial.ttf");
		View cameraView, uiView;
		Text hudText;

		public void Init() {
			var x = (float)Math.Floor(target.X);
			var y = (float)Math.Floor(target.Y + 15);
			var position = $"X: {x}, Y: {y}";

			hudText = new Text(position, font, 25);
			hudText.Scale = new Vector2f(0.5f, 0.5f);
			hudText.FillColor = Color.White;

			cameraView = new View();
			uiView = new View();
		}

		public override void Update() {
			fps.Update();
			var zoom = Input.GetKey(Keyboard.Key.Hyphen) - Input.GetKey(Keyboard.Key.Equal);

			camZoom += zoom * 0.001f;
			camZoom = Math.Clamp(camZoom, 0.1f, 0.28f);

			if (Input.GetKeyDown(Keyboard.Key.Backspace, true)) camZoom = 0.2f;

			cameraView.Center = new Vector2f(target.X, target.Y);

			var x = (float)Math.Floor(target.X);
			var y = (float)Math.Floor(target.Y + 15);
			var fpsText = $"FPS: {fps.GetFPS()}\n";
			var position = $"X: {x}, Y: {y}\n";
			hudText.DisplayedString = fpsText + position;
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
