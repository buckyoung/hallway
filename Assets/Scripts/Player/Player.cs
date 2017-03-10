using UnityEngine;
using System.Collections;
using Hallway.Behavior;

namespace Hallway.Player {

	[RequireComponent (typeof (IMoveable))]

	public class Player : MonoBehaviour {
		private int id = 1;

		public int getId() {
			return id;
		}
	}	
}