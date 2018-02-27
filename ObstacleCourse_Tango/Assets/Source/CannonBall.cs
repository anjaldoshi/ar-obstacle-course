using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	public GameObject cam, cannon;
	Rigidbody rb;
	public float mSpeed = 20f, mTimeAlive = 0f, mMaxAlive = 5f;
	Vector3 mDir;

	void Start () {
		cam = GameObject.Find("Main Camera");
		rb = GetComponent<Rigidbody> ();
		cannon = GameObject.Find("Cannon");  
		mDir = cam.transform.localPosition - cannon.transform.localPosition;
		mDir.Normalize ();
	}

	// Update is called once per frame
	void Update () {
		//transform.localPosition += mDir * mSpeed * Time.deltaTime;
		mTimeAlive += Time.deltaTime;
		if (mTimeAlive > mMaxAlive) {
			Destroy (transform.gameObject);
		}
	}

	void FixedUpdate(){
		rb.AddForce(mDir, ForceMode.Impulse);
	}
}
