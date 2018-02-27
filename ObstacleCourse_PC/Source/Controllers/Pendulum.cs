using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

	Quaternion start, end;

	[SerializeField, Range(0.0f, 360f)]
	private float angle = 90.0f;

	[SerializeField, Range(0.0f, 5.0f)]
	private float speed = 2.0f;

	[SerializeField, Range(0.0f, 10.0f)]
	private float startTime = 0.0f;


	void Start(){
		start = PendulumRotation (angle);
		end = PendulumRotation (-angle);
	}


	void FixedUpdate(){
		startTime += Time.deltaTime;
		transform.localRotation = Quaternion.Lerp (start, end, (Mathf.Sin (startTime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
	}

	void ResetTimer(){
		startTime = 0.0f;
	}

	Quaternion PendulumRotation (float angle){
		var pendulumRotation = transform.rotation;
		Quaternion q = Quaternion.AngleAxis (angle, transform.forward);


		pendulumRotation = q * transform.localRotation;
		return pendulumRotation;
	}

}
