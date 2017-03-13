using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.Player {
	public class PlayersManager : MonoBehaviour {

		private float notMaxZ = -1.0f;
		private float maxZ = -2.0f;

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

			notMax.position = new Vector3(notMax.position.x, notMax.position.y, notMaxZ);
			max.position = new Vector3(max.position.x, max.position.y, maxZ);
		}
	}
}

