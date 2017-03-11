using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.DistanceMinigame {
	public class DistanceMarker : MonoBehaviour {
	
		private GameObject[] players;
		private float globalMaxDistance = 0.0f;

		void Start() {
			players = GameObject.FindGameObjectsWithTag("Player");
		}

		void Update() {
			float playerXPosition = 0.0f;

			foreach (GameObject player in players) {
				playerXPosition = player.transform.position.x;

				if (playerXPosition > globalMaxDistance) {
					globalMaxDistance = playerXPosition;
					this.transform.position = new Vector2(playerXPosition, -3.5f);
				};
			}
		}
	}
}
