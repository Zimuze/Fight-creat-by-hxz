using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellDestory : MonoBehaviour {

	public GameObject baozhaPartical;

	// Use this for initialization
	void Start () {
		Destroy (gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
		Debug.Log (44444444444);
		Instantiate (baozhaPartical,gameObject.transform.position,baozhaPartical.transform.rotation);
	}

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log (1111111111111111);
		Destroy (gameObject);

	}
	void OnCollisionEnter(Collision other) 
	{
		Debug.Log (222222222);
	}
}
