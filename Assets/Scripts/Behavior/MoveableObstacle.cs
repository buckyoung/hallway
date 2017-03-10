using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class MoveableObstacle : MonoBehaviour, IMoveable {
		void Update() {
			move();
		}

		public void move() {
			// TOOD BUCK
			// Scale obstacle speed with overall gamespeed
			transform.position = new Vector2((float)(transform.position.x - Time.deltaTime * 14), transform.position.y);
		}
	}
}
