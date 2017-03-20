using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class GT_Endless_PlayerMovement : MonoBehaviour, IPlayerMovement {
		public bool __DEBUG_LOCK_X = false;

		private Animator animator;
		private float animationLength = 0.30f; // TODO BUCK This should be however long the animation takes to play
		private bool canPerformAction = true;
		private BoxCollider2D boxCollider2D;
		private int playerId; 

		void Start() {
			subscribe();

			playerId = GetComponent<Player>().getId();

			animator = GetComponentInChildren<Animator>();
			boxCollider2D = GetComponent<BoxCollider2D>();
		}

		public bool DEBUG_getLockX() {
			return __DEBUG_LOCK_X;
		}

		public void resetTimeSinceCollided() {
			// do nothing
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
