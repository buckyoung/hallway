using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public interface IEmitable {
		void emit();
		bool canEmit();
	}
}