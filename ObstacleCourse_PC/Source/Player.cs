using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

	public int hp = 100;
	float x = 0f, i = 1f;
	public Text hpText;
	public GameObject panel;

	void Update(){

		if (hp > 0) {
			hpText.text = "HP: " + hp;
		} else {
			hpText.text = "You're Dead!";
		}

		x += Time.deltaTime;
		if (x > i) {
			panel.SetActive (false);
			x = 0f;
		}
	}

	void OnTriggerEnter(Collider other){
		if (hp > 0) {
			hp -= 10;
			panel.SetActive (true);
		} 
	}
}
