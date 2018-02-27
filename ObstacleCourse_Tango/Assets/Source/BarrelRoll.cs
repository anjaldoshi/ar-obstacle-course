using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour {
	
	public GameObject Cam;
	private Vector3 startPos;

	void Start(){
		startPos = transform.localPosition;
	}
	// Update is called once per frame
	void Update () {
		if ((transform.localPosition.z - Cam.transform.localPosition.z) < 5f) {
			if (!gameObject.GetComponent<Rigidbody> ()) {
				gameObject.AddComponent<Rigidbody> ();
			}
		} else {
			Destroy(gameObject.GetComponent<Rigidbody> ());
			transform.localPosition = startPos;
		}
	}
}
