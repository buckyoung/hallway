using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class DuckableHead : MonoBehaviour, IDuckable {
		private MeshRenderer meshRenderer;
		private BoxCollider boxCollider;

		void Start() {
			meshRenderer = GetComponent<MeshRenderer>();
			boxCollider = GetComponent<BoxCollider>();
		}

		public void duck() {
			meshRenderer.enabled = false;
			boxCollider.enabled = false;

			StartCoroutine(endDuck());
		}

		private IEnumerator endDuck() {
			yield return new WaitForSeconds(0.4f);
			meshRenderer.enabled = true;
			boxCollider.enabled = true;
		}
	}
}
