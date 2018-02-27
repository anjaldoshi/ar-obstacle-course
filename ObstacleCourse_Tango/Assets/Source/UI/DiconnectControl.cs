using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DiconnectControl : MonoBehaviour {

	// Use this for initialization
	public Button disconnect;
	GameObject playerSphere;
	public GameObject damage;

	void Start () {
		disconnect.onClick.AddListener (delegate {
			DestroySphere();
		});
	}
	
	void DestroySphere(){
		playerSphere = GameObject.Find ("Player");
		if (playerSphere != null) {
			Destroy (playerSphere);
			damage.SetActive (true);
		}
	}
}
