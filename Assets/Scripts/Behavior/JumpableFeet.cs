using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class JumpableFeet : MonoBehaviour, IJumpable {
		private MeshRenderer meshRenderer;
		private BoxCollider boxCollider;

		void Start() {
			meshRenderer = GetComponent<MeshRenderer>();
			boxCollider = GetComponent<BoxCollider>();
		}

		public void jump() {
			meshRenderer.enabled = false;
			boxCollider.enabled = false;

			StartCoroutine(endJump());
		}

		private IEnumerator endJump() {
			yield return new WaitForSeconds(0.4f); // TODO BUCK scale jump speed with overall game speed
			meshRenderer.enabled = true;
			boxCollider.enabled = true;
		}
	}
}
