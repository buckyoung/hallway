using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class GT_Distance_PlayerMovement : MonoBehaviour, IPlayerMovement {
		public AnimationCurve recoveryCurve;
		public bool __DEBUG_LOCK_X = false;

		private Animator animator;
		private float speed = 0.4f;
		private float timeSinceCollided = 0.0f;
		private float animationLength = 0.30f; // TODO BUCK This should be however long the animation takes to play
		private bool canPerformAction = true;
		private BoxCollider2D boxCollider2D;
		private Keyframe recoveryCurveLastFrame;
		private int playerId; 

		void Start() {
			subscribe();

			playerId = GetComponent<Player>().getId();

			animator = GetComponentInChildren<Animator>();
			boxCollider2D = GetComponent<BoxCollider2D>();

			if (recoveryCurve.length != 0) {
				recoveryCurveLastFrame = recoveryCurve[recoveryCurve.length - 1];
			}
		}

		void Update() {
			timeSinceCollided += Time.deltaTime;

			// Ensure maximum
			if (timeSinceCollided > recoveryCurveLastFrame.time) {
				timeSinceCollided = recoveryCurveLastFrame.time;
			}

			// Calculate speed according to the recoveryCurve
			speed = recoveryCurve.Evaluate(timeSinceCollided);

			// Constantly move to the right
			if (!__DEBUG_LOCK_X) {
				transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
			}
		}

		public bool DEBUG_getLockX() {
			return __DEBUG_LOCK_X;
		}

		public void resetTimeSinceCollided() {
			timeSinceCollided = 0.0f;
		}

		//
		// Private
		//
		private void subscribe() {
			ButtonEventManager.onJumpButtonDown += (eventObject, pid) => {
				if (playerId == pid && canPerformAction) {
					canPerformAction = false;

					animator.SetTrigger("JumpTrigger");
					boxCollider2D.offset = new Vector2(0.0f, 1.0f);

					StartCoroutine(resetAction(animationLength));
				}
			};

			ButtonEventManager.onSlideButtonDown += (eventObject, pid) => {
				if (playerId == pid && canPerformAction) {
					canPerformAction = false;

					animator.SetTrigger("SlideTrigger");
					boxCollider2D.offset = new Vector2(0.0f, 0.0f);

					StartCoroutine(resetAction(animationLength));
				}
			};

			ButtonEventManager.onDiveButtonDown += (eventObject, pid) => {
				if (playerId == pid && canPerformAction) {
					canPerformAction = false;

					animator.SetTrigger("DiveTrigger");
					boxCollider2D.offset = new Vector2(0.0f, 0.75f);

					StartCoroutine(resetAction(animationLength * 2));
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
