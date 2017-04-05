using UnityEngine;
using System.Collections;
using Hallway.Behavior;
using Hallway.System;

namespace Hallway.Player {
	public class Player : MonoBehaviour {
		[SerializeField] private int id = 1;
		[SerializeField] private Color tintColor;
		public delegate void PlayerDeathEvent(Player eventObject, int id);
		public static event PlayerDeathEvent onPlayerDeath;

		public int getId() {
			return id;
		}

		public Color getTint() {
			return tintColor;
		}

		void OnDestroy() {
			if (onPlayerDeath != null) onPlayerDeath(this, id);
		}
	}
}	
