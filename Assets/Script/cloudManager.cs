using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudManager : MonoBehaviour {


	public GameObject windObject;

	Vector3 wind;
	// Use this for initialization
	void Start () {
		wind = windObject.GetComponent<Airplane_Status>().windSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(wind * 10 * Time.deltaTime);
	}
}
