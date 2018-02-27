using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	public GameObject player, cannon;
	Rigidbody rb;
	public float mSpeed = 20f, mTimeAlive = 0f, mMaxAlive = 5f;
	Vector3 mDir;

	void Start () {
		player = GameObject.Find("Player");
		rb = GetComponent<Rigidbody> ();
		cannon = GameObject.Find("CannonPrefab");  
		mDir = player.transform.localPosition - cannon.transform.localPosition;
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
			rb.AddForce (mDir, ForceMode.VelocityChange);
		}
}

