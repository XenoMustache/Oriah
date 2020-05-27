using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Oriah {
	public class Game {
		public Game() => Run();

		RenderWindow window;
		Clock clock;
		Time time;

		void Run() {
			ContextSettings settings = new ContextSettings();

			window = new RenderWindow(new VideoMode(1280, 720), "Oriah", Styles.Default, settings);
			window.Closed += (s, e) => window.Close();
			window.Resized += (s, e) => window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
			window.SetActive(true);

			Initialize();

			while (window.IsOpen) Loop();
		}

		void Initialize() { clock = new Clock(); }

		void Loop() {
			window.Clear(Color.Black);
			window.DispatchEvents();

			Update();
			Render();
			Input();

			window.Display();

			clock.Restart();
		}

		void Update() {
			time = clock.ElapsedTime;
		}

		void Render() {

		}

		void Input() {

		}
	}
}
