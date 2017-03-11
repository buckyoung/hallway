using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class EmittersManager : MonoBehaviour {

		public bool _shouldEmit = true;
		private IEmitable[] emitters;

		void Start() {
			emitters = GetComponentsInChildren<IEmitable>();
		}

		void Update() {
			foreach (IEmitable emitter in emitters) {
				if (_shouldEmit && emitter.canEmit()) {
					emitter.emit();

					// TODO BUCK
					// Make a better system for managing emitters & not allowing them to fire too close to each other
					// (This system favors the emitters earlier in the emitters[] array)
					_shouldEmit = false;
					StartCoroutine(wait(0.4f)); // Cant spawn 2 obstacles within X time of each other
					// TODO BUCK scale this number ^ with speed of hallway
				}
			}
		}

		private IEnumerator wait(float seconds) {
			yield return new WaitForSeconds(seconds);
			_shouldEmit = true;
		}
	}
}
