using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hallway.DistanceMinigame;
using Hallway.Player;

namespace Hallway.System {
	public class DistanceGameManager : MonoBehaviour {
		private GUIStyle guiStyle = new GUIStyle();
		private int winId = 0;

		void Start() {
			guiStyle.fontSize = 24;
			guiStyle.normal.textColor = Color.white;
			guiStyle.clipping = TextClipping.Clip;

			Player.Player.onPlayerDeath += (eventObject, id) => {
				int maxId = DistanceMarker.getMaxId();

				if (id != maxId) {
					winId = maxId;
					return;
				}

				if (id == maxId && PlayersManager.getNumberOfPlayers() == 0) {
					winId = maxId;	
				}
			};
		}

		void OnGUI() {
			if (winId != 0) {
				GUI.Label(new Rect (Screen.width / 2 - 75, Screen.height / 2, 150, 100), "Player " + winId + " Wins", guiStyle);
			}
		}
	}	
}

