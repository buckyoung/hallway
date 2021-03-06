﻿using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class PlayerCollision : MonoBehaviour {

		public AnimationCurve knockbackCurve;

		private int numberOfTimesHit = 0;

		private Animator animator;
		private IPlayerMovement playerMovementManager;

		void Start() {
			animator = GetComponentInChildren<Animator>();
			playerMovementManager = GetComponent<IPlayerMovement>();
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.tag == "obstacle") {
				float knockback = knockbackCurve.Evaluate(++numberOfTimesHit);

				// TODO BUCK Get the knockback off the obstacle
				if (!playerMovementManager.DEBUG_getLockX()) {
					transform.position = new Vector3(transform.position.x - knockback, transform.position.y, transform.position.z);
				}
					
				playerMovementManager.resetTimeSinceCollided();

				// Trigger Kneeling Animation
				animator.SetTrigger("RollTrigger");

				// Destroy the object on contact
				Destroy(other.gameObject);
			}
		}
	}
}
