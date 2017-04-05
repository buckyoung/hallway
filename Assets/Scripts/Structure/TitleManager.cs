using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hallway.System;

public class TitleManager : MonoBehaviour {
	void Start () {
		ButtonEventManager.onJumpButtonDown += test;
	}

	void OnDisable() {
		ButtonEventManager.onJumpButtonDown -= test;
	}

	void test(ButtonEventManager eventObject, int playerId) {
		SceneManager.LoadScene(playerId);
	}
}
