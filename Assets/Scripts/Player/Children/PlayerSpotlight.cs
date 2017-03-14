using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.DistanceMinigame {
	public class PlayerSpotlight : MonoBehaviour {
		void Start() {
			GetComponent<Light>().color = GetComponentInParent<Player.Player>().getTint();
		}
	}
}
