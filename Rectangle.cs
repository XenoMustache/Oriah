using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SFML.Graphics;
using SFML.System;
using System;

namespace Oriah {
	class Rectangle : IDisposable {
		public RectangleShape rect;
		public Vector2f position;

		Color color;
		RandomizerNumber<int> colorPicker;

		public Rectangle() {
			colorPicker = new RandomizerNumber<int>(new FieldOptionsInteger() { Min = 1, Max = 4 });

			switch (colorPicker.Generate()) {
				case 1:
					color = Color.Red;
					break;
				case 2:
					color = Color.Green;
					break;
				case 3:
					color = Color.Blue;
					break;
			}

			rect = new RectangleShape(new Vector2f(10, 10));

			rect.Origin = rect.Size / 2;
			rect.FillColor = color;
		}

		public void Update() {
			rect.Position = position;
		}

		protected virtual void Dispose(bool disposing) { }

		public void Dispose() {
			rect.Dispose();

			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
