using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearAllController : MonoBehaviour {
	public Button ClearAll;
	// Use this for initialization
	void Start () {
		ClearAll.onClick.AddListener (delegate {
			DeleteAllObjects();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DeleteAllObjects() {
		if (AxesControl.selectedSphere != null) {
			Destroy (AxesControl.selectedSphere);
			AxesControl.selectedSphere = null;
		}
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("GameObject");
		for (int i = 0; i < objs.Length; i++) {
			Destroy (objs [i]);
		}
		GameObject[] players = GameObject.FindGameObjectsWithTag ("PlayerTag");
		for (int i = 0; i < players.Length; i++) {
			Destroy (objs [i]);
		}
	}
}
