using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.System {
	public class Killbox : MonoBehaviour {
		void OnTriggerEnter2D(Collider2D other) {
			Destroy(other.gameObject);
		}
	}	
}
