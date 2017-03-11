using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.DistanceMinigame {
	public class PlayerSpriteManager : MonoBehaviour {
		void Start() {
			GetComponent<SpriteRenderer>().color = GetComponentInParent<Player.Player>().getTint();
		}
	}
}
