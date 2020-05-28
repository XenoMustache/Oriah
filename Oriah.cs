using Oriah.States;
using Xenon.Client;

namespace Oriah {
	public class Oriah : Game {
		public Oriah(string name) : base(name) { }

		protected override void Init() {
			stateManager.AddState(new _0_TestState(), 0);
			stateManager.Goto(0, false, true);

			base.Init();
		}

		protected override void Update(double deltaTime) { }
		protected override void Render() { }
	}
}
