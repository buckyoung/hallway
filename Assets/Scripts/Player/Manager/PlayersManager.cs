using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hallway.DistanceMinigame;

namespace Hallway.Player {
	public class PlayersManager : MonoBehaviour {

		private float notMaxZ = -1.0f;
		private float maxZ = -2.0f;
		private float notMaxY = 0.0f;
		private float maxY = -0.05f;
		private static int numberOfPlayers = 2;


		void Start() {
			Player.onPlayerDeath += (eventObject, id) => {
				numberOfPlayers--;
			};
		}

		void Update() {
			// Determine who is in front and change their Z value 
			Transform max = null;
			Transform notMax = null;

			foreach (Transform child in transform) {
				if (max == null) {
					max = child;
				} else if (child.position.x > max.position.x) {
					notMax = max; 
					max = child;
				} else {
					notMax = child;
				}
			}

			if (!(max == null || notMax == null)) {
				notMax.position = new Vector3(notMax.position.x, notMaxY, notMaxZ);
				max.position = new Vector3(max.position.x, maxY, maxZ);
			}
		}

		public static int getNumberOfPlayers() {
			return numberOfPlayers;
		}
	}
}

