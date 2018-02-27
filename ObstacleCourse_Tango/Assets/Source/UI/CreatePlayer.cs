using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ASL.Manipulation.Objects;
using ASL.Adapters.PUN;

public class CreatePlayer : MonoBehaviour {

	private ObjectInteractionManager objManager;
	public Button createPlayer;
	public Camera tangoCamera;
	GameObject playerSphere;

	void Start () {
		createPlayer.onClick.AddListener (delegate {
			CreateSphere();
		});
	}

	void CreateSphere(){
		playerSphere = GameObject.Find ("Player");
		if (playerSphere==null) {
			objManager = GameObject.Find ("ObjectInteractionManager").GetComponent<ObjectInteractionManager> ();
			string prefabName = "Player";
			Quaternion rotation = Quaternion.identity;
			Vector3 scale = Vector3.one;
			objManager.Instantiate (prefabName, tangoCamera.transform.position, rotation, scale);
		}
	}
}
