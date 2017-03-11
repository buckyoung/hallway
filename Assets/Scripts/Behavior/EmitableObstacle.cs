using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class EmitableObstacle : MonoBehaviour, IEmitable {

		private bool _canEmit = true;

		public void emit() {
			GameObject resource = (GameObject)Instantiate(
				Resources.Load("Obstacle"), 
				transform.position,
				Quaternion.identity
			);

			resource.transform.SetParent(this.transform);
			Destroy(resource, 5);

			StartCoroutine(waitRandom(1, 3));
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
