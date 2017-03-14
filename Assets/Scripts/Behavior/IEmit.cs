using UnityEngine;
using System.Collections;

namespace Hallway.Behavior {
	public interface IEmit {
		void emit();
		bool canEmit();
	}
}