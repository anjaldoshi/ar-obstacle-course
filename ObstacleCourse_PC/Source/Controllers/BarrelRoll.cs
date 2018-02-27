using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour {
	
	private Vector3 startPos;

	void Start(){
		startPos = transform.localPosition;
	}
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");
		if (player == null)
			return;
		if (Mathf.Abs(transform.parent.transform.localPosition.z - player.transform.localPosition.z) < 2.5f) {
			if (!gameObject.GetComponent<Rigidbody> ()) {
				gameObject.AddComponent<Rigidbody> ();
			}
		} else {
			Destroy(gameObject.GetComponent<Rigidbody> ());
			transform.localPosition = startPos;
		}
	}
}
