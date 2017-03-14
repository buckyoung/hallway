using UnityEngine;
using System.Collections;

namespace Hallway.System {
	public class ButtonEventManager : MonoBehaviour {
		// Events
		public delegate void ButtonDownEvent(ButtonEventManager eventObject, int playerId);
		public static event ButtonDownEvent onJumpButtonDown;
		public static event ButtonDownEvent onSlideButtonDown;
		public static event ButtonDownEvent onDiveButtonDown;

		void Update() {
			// P1 & 2: Jump Button
			for(int i = 1; i <= 2; i++) {
				if (Input.GetButtonDown(i + "_JUMP")) {
					if (onJumpButtonDown != null) onJumpButtonDown(this, i);
				}
			}

			// P1 & 2: Slide Button
			for(int i = 1; i <= 2; i++) {
				if (Input.GetButtonDown(i + "_SLIDE")) {
					if (onSlideButtonDown != null) onSlideButtonDown(this, i);
				}
			}

			// P1 & 2: Dive Button
			for(int i = 1; i <= 2; i++) {
				if (Input.GetButtonDown(i + "_DIVE")) {
					if (onDiveButtonDown != null) onDiveButtonDown(this, i);
				}
			}
		}

	}
}