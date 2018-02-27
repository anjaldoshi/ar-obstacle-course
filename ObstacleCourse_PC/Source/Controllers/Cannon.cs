using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ASL.Manipulation.Objects;

public class Cannon : MonoBehaviour {

	public GameObject cBall;
	public float interval = 2f, x = 0f;
	Vector3 mDir;
	private ObjectInteractionManager objManager;

	// Use this for initialization
	void Start () {
		objManager = GameObject.Find ("ObjectInteractionManager").GetComponent<ObjectInteractionManager> ();
	}

	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");
		if (player == null)
			return;
		mDir = player.transform.localPosition - transform.localPosition;
		mDir.Normalize ();
//		Quaternion q = Quaternion.FromToRotation (-transform.right, mDir);
//		transform.localRotation = q;
		if (Vector3.Distance(transform.localPosition, player.transform.localPosition) < 5f) {
			x += Time.deltaTime;
			if (x > interval) {
				objManager.Instantiate (cBall.name, transform.localPosition + 2*mDir, Quaternion.identity,Vector3.one);
				x = 0f;
			}
		}
	}
}
