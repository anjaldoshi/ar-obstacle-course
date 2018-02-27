using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public GameObject cBall, cam;
	public float interval = 1f, x = 0f;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.localPosition, cam.transform.localPosition) < 15f) {
			x += Time.deltaTime;
			if (x > interval) {
				Instantiate (cBall, transform.localPosition, Quaternion.identity);
				x = 0f;
			}
		}
	}
}
