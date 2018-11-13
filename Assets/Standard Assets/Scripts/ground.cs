using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour {

	public static int triggered = 0;

	void OnTriggerEnter  (Collider collider) {
		triggered=1;

		Debug.Log ("ground====111111111111");
	}

	void OnTriggerExit  (Collider collider) {
		triggered=0;
		Debug.Log ("ground====00000000");
	}
}
