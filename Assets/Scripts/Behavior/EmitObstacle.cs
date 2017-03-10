using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class EmitObstacle : MonoBehaviour, IEmit {

		public bool _canEmit = true;

		public void emit() {

			// TODO BUCK
			// I beleive there is a specific way we have to clean these up.
			// Also, alternatively: we could create a pool of 20 or so to reuse
			Instantiate(
				Resources.Load("Obstacle"), 
				transform.position,
				Quaternion.identity
			);

			StartCoroutine(waitRandom(1, 5));
		}

		public bool canEmit() {
			return _canEmit;
		}

		private IEnumerator waitRandom(int min, int max) {
			_canEmit = false;
			float randNum = Random.value  * (max - min) + min;
			yield return new WaitForSeconds(randNum);
			_canEmit = true;
		}
	}
}
