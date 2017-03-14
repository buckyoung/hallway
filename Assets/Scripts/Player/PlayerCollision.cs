using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class PlayerCollision : MonoBehaviour {
		
		private float __knockback = 0.5f; // TODO BUCK Knockback should be set on the obstacle
		private PlayerMovement playerMovementManager;

		void Start() {
			playerMovementManager = GetComponent<PlayerMovement>();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.tag == "obstacle") {
				// TODO BUCK Get the knockback off the obstacle
				if (!playerMovementManager.__DEBUG_LOCK_X) {
					transform.position = new Vector3(transform.position.x - __knockback, transform.position.y, transform.position.z);
				}
					
				playerMovementManager.resetTimeSinceCollided();

				// Destroy the object on contact
				Destroy(other.gameObject);
			}
		}
	}
}
