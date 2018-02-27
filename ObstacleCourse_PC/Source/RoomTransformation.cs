using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoomTransformation : MonoBehaviour {

	public Button transformRoom;
	// Use this for initialization
	void Start () {
		transformRoom.onClick.AddListener (delegate {
			RoomTransform();
		});
	}
	// Update is called once per frame
	void RoomTransform () {
		GameObject[] roomObj = GameObject.FindGameObjectsWithTag ("Room");
		if (roomObj == null) {
			return;
		}
		for(int i = 0; i < roomObj.Length ; i++){
			roomObj [i].AddComponent<MeshCollider> ();
			roomObj [i].transform.position += new Vector3 (-2.5f, 0.5f, 7.5f);
		}
	}
}
