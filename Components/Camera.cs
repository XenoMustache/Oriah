using SFML.Graphics;
using SFML.System;
using Xenon.Common.Object;

namespace Oriah.Components {
	public class Camera : Componenet {
		public float zoom = 1;
		public Vector2f center, size;
		View cameraView;

		public override void Render(RenderWindow window) {
			cameraView = new View(center, size);
			cameraView.Zoom(zoom);

			window.SetView(cameraView);
		}

		public override void Update(double deltaTime) { }
	}
}
