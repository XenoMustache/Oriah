using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Oriah {
	public class Game {
		public Game() => Run();

		double time = 0.0, deltatime = 0.01, currentTime, accumulator = 0.0, secondsPerFrame = 0.25;
		Clock clock;
		RenderWindow window;

		RectangleShape rect;

		void Run() {
			ContextSettings settings = new ContextSettings();

			window = new RenderWindow(new VideoMode(1280, 720), "Oriah", Styles.Default, settings);
			window.Closed += (s, e) => window.Close();
			window.Resized += (s, e) => window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
			window.SetActive(true);

			Initialize();

			while (window.IsOpen) Loop();
		}

		void Initialize() {
			clock = new Clock();
			currentTime = clock.Restart().AsSeconds();

			rect = new RectangleShape(new Vector2f(100, 100));
			rect.Position = new Vector2f((float)window.Size.X / 2, 0);
			rect.Origin = rect.Size / 2;
			rect.FillColor = Color.Red;
		}

		void Loop() {
			double newTime = clock.ElapsedTime.AsSeconds();
			double frameTime = newTime - currentTime;

			if (frameTime > secondsPerFrame) frameTime = secondsPerFrame;
			currentTime = newTime;

			accumulator += frameTime;

			window.Clear(Color.Black);
			window.DispatchEvents();

			Input();

			while (accumulator >= deltatime) {
				Update(deltatime);
				time += deltatime;
				accumulator -= deltatime;
			}

			Render();

			window.Display();
		}

		void Update(double deltaTime) {
			rect.Position += new Vector2f(0, 100 * (float)deltaTime);
		}

		void Render() {
			window.Draw(rect);
		}

		void Input() { }
	}
}
