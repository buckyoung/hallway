using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.System {
	public class Killbox : MonoBehaviour {
		void OnTriggerStay2D(Collider2D other) {
			Debug.Log(other.name);

			if (other.gameObject.tag == "Player") {
				// Emit Event
			}
			Destroy(other.gameObject);
		}
	}	
}
