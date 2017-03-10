using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public class MoveablePlayer : MonoBehaviour, IMoveable {
		private int playerId;
		private IJumpable jumpBehavior;
		private IDuckable duckBehavior;

		void Start() {
			playerId = GetComponent<Player.Player>().id;
			jumpBehavior = GetComponentInChildren<IJumpable>();
			duckBehavior = GetComponentInChildren<IDuckable>();
		}

		public void move() {

			// TODO BUCK
			// Do not allow the player to jump or duck
			// if they are in the middle of doing one of those things.
			// This should probably be handled by checking a boolean
			// on their jumpBehavior & duckBehavior
			// (add this to the IJumpable and IDuckable interfaces)

			if (Input.GetButton(playerId + "-JUMP")) {
				jumpBehavior.jump();
				return; // Do not allow both jump and duck to be pressed simultaneously
			}

			if (Input.GetButton(playerId + "-DUCK")) {
				duckBehavior.duck();
			}
		}
	}
}
