﻿using Oriah.Objects;
using SFML.System;
using Xenon.Common.State;

namespace Oriah.States {
	public class _1_WorldState : GameState {
		WorldHandler world = new WorldHandler();
		Player player = new Player();

		public override void Init() {
			base.Init();

			Objects.Add(world);
			Objects.Add(player);

			var w = world.Generate(10);
			w.Wait();

			player.Init(new Vector2f((world.size / 2) * 128, -9));
			player.chunks = world.chunks;
			world.player = player;
		}

		public override void Update() {
			base.Update();
		}

		public override void Render() {
			base.Render();
		}
	}
}
