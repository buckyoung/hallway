using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class Player : MonoBehaviour {
		public int id = 1;
		private float speed = 0.4f;
		private float __knockback = 2.0f; // TODO BUCK Knockback should be set on the obstacle 
		private float __recoverTimeAfterAction = 0.35f; // TODO BUCK This should be however long the animation takes to play

		private bool canPerformAction = true;
		private BoxCollider2D boxCollider2D;

		void Start() {
			subscribe();

			boxCollider2D = GetComponent<BoxCollider2D>();
		}

		void Update() {
			// Constantly move to the right
			transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
		}

		void OnTriggerEnter2D(Collider2D other) {
			// TODO BUCK Get the knockback off the obstacle
			transform.position = new Vector2(transform.position.x - __knockback, transform.position.y);

			// Destroy the object on contact
			Destroy(other.gameObject);
		}

		public int getId() {
			return id;
		}

		// Private

		void subscribe() {
			ButtonEventManager.onJumpButtonDown += (eventObject, playerId) => {
				if (id == playerId && canPerformAction) {
					canPerformAction = false;

					boxCollider2D.offset = new Vector2(0.0f, 1.0f);

					StartCoroutine(resetAction(__recoverTimeAfterAction));
				}
			};

			ButtonEventManager.onSlideButtonDown += (eventObject, playerId) => {
				if (id == playerId && canPerformAction) {
					canPerformAction = false;

					boxCollider2D.offset = new Vector2(0.0f, 0.0f);

					StartCoroutine(resetAction(__recoverTimeAfterAction));
				}
			};
		}

		private IEnumerator resetAction(float seconds) {
			yield return new WaitForSeconds(seconds);
			boxCollider2D.offset = new Vector2(0.0f, 0.5f);
			canPerformAction = true;
		}
	}	
}