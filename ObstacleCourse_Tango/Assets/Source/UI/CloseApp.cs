using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CloseApp : MonoBehaviour {

	public Button closeApp;

	void Start () {
		closeApp.onClick.AddListener (delegate {
			AppQuit();
		});
	}

	void AppQuit(){
		Debug.Log ("APP Quit!");
		Application.Quit ();
	}
}
