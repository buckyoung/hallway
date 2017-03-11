using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class MoveableBackdrop : MonoBehaviour, IMoveable {
		private float pos = 1.0f;
		private MeshRenderer meshRenderer;

		void Start() {
			meshRenderer = GetComponent<MeshRenderer>();
		}

		void Update() {
			move();
		}

		public void move() {
			// TOOD BUCK
			// Scale obstacle speed with overall gamespeed
			pos -= Time.deltaTime * 2;

			if (pos < -1.0f) {
				pos += 1.0f;
			}

			meshRenderer.material.mainTextureOffset = new Vector2(pos, 0);
		}
	}
}
