using UnityEngine;
using System.Collections;
using Hallway.Behavior;

namespace Hallway.Player {

	[RequireComponent (typeof (IMoveable))]

	public class Player : MonoBehaviour {
		public int id = 1;
		public IMoveable moveBehavior;

		void Start() {
			moveBehavior = GetComponent<IMoveable>();
		}

		void Update() {
			moveBehavior.move();
		}
	}	
}