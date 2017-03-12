using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class Player : MonoBehaviour {
		public int id = 1;
		public AnimationCurve recoveryCurve;
		public Color tintColor;

		private Animator animator;

		private float speed = 0.4f;

		private float secondsSinceCollided = 0.0f;

		private float __knockback = 0.5f; // TODO BUCK Knockback should be set on the obstacle
		private float __recoverTimeAfterAction = 0.30f; // TODO BUCK This should be however long the animation takes to play

		private bool canPerformAction = true;
		private BoxCollider2D boxCollider2D;

		private Keyframe recoveryCurveLastFrame;

		void Start() {
			subscribe();

			animator = GetComponentInChildren<Animator>();
			boxCollider2D = GetComponent<BoxCollider2D>();

			if (recoveryCurve.length != 0) {
				recoveryCurveLastFrame = recoveryCurve[recoveryCurve.length - 1];
			}
		}

		void Update() {
			secondsSinceCollided += Time.deltaTime;

			// Ensure maximum
			if (secondsSinceCollided > recoveryCurveLastFrame.time) {
				secondsSinceCollided = recoveryCurveLastFrame.time;
			}

			// Calculate speed according to the recoveryCurve
			speed = recoveryCurve.Evaluate(secondsSinceCollided);

			// Constantly move to the right
			transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
		}

		void OnTriggerEnter2D(Collider2D other) {
			if (other.tag == "obstacle") {
				// TODO BUCK Get the knockback off the obstacle
				transform.position = new Vector2(transform.position.x - __knockback, transform.position.y);

				secondsSinceCollided = 0.0f;;

				// Destroy the object on contact
				Destroy(other.gameObject);
			}
		}

		public int getId() {
			return id;
		}

		public Color getTint() {
			return tintColor;
		}

		// Private

		void subscribe() {
			ButtonEventManager.onJumpButtonDown += (eventObject, playerId) => {
				if (id == playerId && canPerformAction) {
					canPerformAction = false;

					animator.SetInteger("Action", 1);
					boxCollider2D.offset = new Vector2(0.0f, 1.0f);

					StartCoroutine(resetAction(__recoverTimeAfterAction));
				}
			};

			ButtonEventManager.onSlideButtonDown += (eventObject, playerId) => {
				if (id == playerId && canPerformAction) {
					canPerformAction = false;

					animator.SetInteger("Action", 2);
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
