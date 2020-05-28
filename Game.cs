using Coroutine;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Oriah {
	public class Game {
		public Game() => Run();

		double deltatime = 0.01, currentTime, accumulator, secondsPerFrame = 0.05;
		Clock clock;
		RenderWindow window;

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
				accumulator -= deltatime;
			}

			Render();

			window.Display();
		}

		void Input() { }
		void Update(double deltaTime) { }
		void Render() { }
	}
}
