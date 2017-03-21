using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hallway.Player {
	public interface IPlayerMovement {
		bool DEBUG_getLockX();
		void resetTimeSinceCollided();
	}
}
