using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class EmitableBackdrop : MonoBehaviour, IEmitable {

		private bool _canEmit = true;

		private float secondsToWait = 0.39f;

		void Update() {
			if (canEmit()) {
				emit();
			}
		}

		public void emit() {

			// TODO BUCK
			// I beleive there is a specific way we have to clean these up.
			// Also, alternatively: we could create a pool of 20 or so to reuse
			Instantiate(
				Resources.Load("Backdrop"), 
				transform.position,
				Quaternion.identity
			);

			_canEmit = false;

			StartCoroutine(wait(secondsToWait));
		}

		public bool canEmit() {
			return _canEmit;
		}

		private IEnumerator wait(float seconds) {
			yield return new WaitForSeconds(seconds);
			_canEmit = true;
		}
	}
}
