using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.DistanceMinigame {
	public class DistanceMarker : MonoBehaviour {
	
		private GameObject[] players;
		private Player.Player[] playerScripts;
		private float globalMaxDistance = 0.0f;
		private Light myLight;
		private GUIStyle guiStyle = new GUIStyle();

		void Start() {
			myLight = GetComponentInChildren<Light>();

			GameObject[] taggedPlayers = GameObject.FindGameObjectsWithTag("Player");

			players = new GameObject[taggedPlayers.Length];
			playerScripts = new Player.Player[taggedPlayers.Length];

			// Sort tagged players
			for (int i = 0; i < taggedPlayers.Length; i++) {
				Player.Player playerScript = taggedPlayers[i].GetComponent<Player.Player>();
				int playerId = playerScript.getId();
				int playerIndex = playerId - 1;

				players[playerIndex] = taggedPlayers[i];
				playerScripts[playerIndex] = taggedPlayers[i].GetComponent<Player.Player>();
			}

			// GUI Style
			guiStyle.fontSize = 24;
			guiStyle.normal.textColor = Color.black;
			guiStyle.clipping = TextClipping.Clip;
		}

		void Update() {
			float playerXPosition = 0.0f;
			myLight.range = 10;

			for (int i = 0; i < players.Length; i++) {
				if (players [i] == null) {
					continue;
				}

				playerXPosition = players[i].transform.position.x;

				if (playerXPosition > globalMaxDistance) {
					globalMaxDistance = playerXPosition;
					this.transform.position = new Vector2(playerXPosition, transform.position.y); // Move rig with player
					myLight.color = playerScripts[i].getTint(); // Tint the light according to the player setting the record
					myLight.range = 14; // Brighten the light upon new record
				}
			}
		}

		void OnGUI() {
			float dist = (float)(((int)(globalMaxDistance * 100)) / 10.0f);

			Vector2 pos = (Vector2)Camera.main.WorldToScreenPoint(transform.position);

			GUI.Label(new Rect(pos.x - 25, Screen.height/3 * 2 + 25, 100, 100), dist.ToString(), guiStyle); 
		}
	}
}
