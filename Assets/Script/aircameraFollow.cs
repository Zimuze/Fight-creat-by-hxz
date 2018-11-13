using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircameraFollow : MonoBehaviour {

	public GameObject air;

	Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position - air.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = air.transform.position + pos;
		transform.rotation = air.transform.rotation;
	}
}
