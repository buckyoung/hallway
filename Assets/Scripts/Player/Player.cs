using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class Player : MonoBehaviour {
		public int id = 1;
		public Color tintColor;

		public int getId() {
			return id;
		}

		public Color getTint() {
			return tintColor;
		}
	}
}
