using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletionController : MonoBehaviour {
	public Button DeleteButton;
	// Use this for initialization
	void Start () {
		DeleteButton.onClick.AddListener (delegate {
			DeleteObject ();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DeleteObject() {
		if (AxesControl.selectedSphere != null) {
			Destroy (AxesControl.selectedSphere);
			AxesControl.selectedSphere = null;
		}
	}
}
