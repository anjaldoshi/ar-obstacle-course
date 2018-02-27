using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AxesControl : MonoBehaviour {
	public Toggle Translate;
	public Toggle Scale;
	public Toggle Rotate;
	public Toggle Local;

	public static GameObject selectedSphere;
	public Transform Axes;
	GameObject AxesObj;
	GameObject selectedAxis;
	Color ObjColor;
	float x, y;

	// Use this for initialization
	void Start () {
		Local.onValueChanged.AddListener (delegate {
			if(Local.isOn && selectedSphere != null && selectedAxis != null)
				AxesObj.transform.localRotation = selectedSphere.transform.localRotation;
			else if(!Local.isOn && selectedSphere != null && selectedAxis != null)
				AxesObj.transform.localRotation = Quaternion.identity;
		});
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt))
			return;
		GameObject hitObj = GetHitObj ();
		if (hitObj != null)
			Debug.Log (hitObj.name);
		if (selectedAxis != null)
			Debug.Log (selectedAxis.name);
		SelectSphere (hitObj);
		CreateAxes ();
		SelectAxis (hitObj);
		x = Input.GetAxis ("Mouse X");
		y = Input.GetAxis ("Mouse Y");
		ControlAxes (x,y);
	}

	GameObject GetHitObj() {
		GameObject hitObj = null;
		if (Input.GetMouseButtonDown (0)) {
			if (!EventSystem.current.IsPointerOverGameObject ()) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					hitObj = hit.collider.gameObject;
					/*while (hitObj.transform.parent != null)
						hitObj = hitObj.transform.parent.gameObject;*/
				}
			}
		}
		return hitObj;
	}

	void SelectSphere(GameObject hitObj) {
		if (hitObj != null) {
			if (selectedSphere != null && ((hitObj.tag == "GameObject")))
			if (selectedSphere.GetComponent<Renderer> () != null)
				selectedSphere.GetComponent<Renderer> ().material.color = ObjColor;
			if (hitObj.tag != "GameObject")
				return;
			while (hitObj.transform.parent != null)
				hitObj = hitObj.transform.parent.gameObject;
			selectedSphere = hitObj;
			if (selectedSphere.GetComponent<Renderer> () != null) {
				ObjColor = selectedSphere.GetComponent<Renderer> ().material.color;
				hitObj.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			}
		} else if (hitObj == null && Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			if (selectedSphere != null && selectedSphere.GetComponent<Renderer> () != null)
				selectedSphere.GetComponent<Renderer> ().material.color = ObjColor;
			selectedSphere = null;
		}
	}

	void CreateAxes() {
		if (selectedSphere != null && AxesObj == null)
			AxesObj = Instantiate (Axes, selectedSphere.transform.position, isLocalRotation (selectedSphere)).gameObject;
		else if (selectedSphere == null && AxesObj!= null)
			AxesObj.SetActive (false);
		else if (selectedSphere != null && AxesObj != null) {
			AxesObj.SetActive (true);
			AxesObj.transform.position = selectedSphere.transform.position;
			AxesObj.transform.rotation = isLocalRotation (selectedSphere);
		}
	}

	Quaternion isLocalRotation(GameObject obj) {
		if (Local.isOn)
			return obj.transform.localRotation;
		return Quaternion.identity;
	}
	void SelectAxis(GameObject hitObj) {
		if (hitObj != null && Input.GetMouseButtonDown (0)) {
			if (hitObj.name == "X" || hitObj.name == "Y" || hitObj.name == "Z") {
				if (selectedAxis != null) {
					if (selectedAxis.name == "X")
						selectedAxis.GetComponent<Renderer> ().material.color = Color.red;
					else if (selectedAxis.name == "Y")
						selectedAxis.GetComponent<Renderer> ().material.color = Color.green;
					else if (selectedAxis.name == "Z")
						selectedAxis.GetComponent<Renderer> ().material.color = Color.blue;
				}
				selectedAxis = hitObj;
				selectedAxis.GetComponent<Renderer> ().material.color = Color.yellow;
			}
		} else if (selectedAxis != null && (Input.GetMouseButtonUp (0))) {
			if (selectedAxis.name == "X")
				selectedAxis.GetComponent<Renderer> ().material.color = Color.red;
			else if (selectedAxis.name == "Y")
				selectedAxis.GetComponent<Renderer> ().material.color = Color.green;
			else if (selectedAxis.name == "Z")
				selectedAxis.GetComponent<Renderer> ().material.color = Color.blue;
			selectedAxis = null;
		}
	}

	void ControlAxes (float x, float y) {
		if (selectedAxis == null || selectedSphere == null)
			return;
		if (!Local.isOn) {
			if (Translate.isOn) {
				if (selectedAxis.name == "X")
					selectedSphere.transform.localPosition += Vector3.right * x * 0.35f;
				else if (selectedAxis.name == "Y")
					selectedSphere.transform.localPosition += Vector3.up * y * 0.35f;
				else if (selectedAxis.name == "Z")
					selectedSphere.transform.localPosition += Vector3.forward * -x * 0.35f;
			} else if (Scale.isOn) {
				if (selectedAxis.name == "X")
					selectedSphere.transform.localScale += Vector3.right * x * 0.35f;
				else if (selectedAxis.name == "Y")
					selectedSphere.transform.localScale += Vector3.up * y * 0.35f;
				else if (selectedAxis.name == "Z")
					selectedSphere.transform.localScale += Vector3.forward * -x * 0.35f;
			} 
		} else {
			if (Translate.isOn) {
				if (selectedAxis.name == "X")
					selectedSphere.transform.localPosition += selectedSphere.transform.right * x * 0.35f;
				else if (selectedAxis.name == "Y")
					selectedSphere.transform.localPosition += selectedSphere.transform.up * y * 0.35f;
				else if (selectedAxis.name == "Z")
					selectedSphere.transform.localPosition += selectedSphere.transform.forward * -x * 0.35f;
			} else if (Scale.isOn) {
				if (selectedAxis.name == "X")
					selectedSphere.transform.localScale += selectedSphere.transform.right * x * 0.35f;
				else if (selectedAxis.name == "Y")
					selectedSphere.transform.localScale += selectedSphere.transform.up * y * 0.35f;
				else if (selectedAxis.name == "Z")
					selectedSphere.transform.localScale += selectedSphere.transform.forward * -x * 0.35f;
			} 
		}
		if (Rotate.isOn) {
			if (selectedAxis.name == "X")
				selectedSphere.transform.localRotation = selectedSphere.transform.localRotation *Quaternion.AngleAxis (30f * x, Vector3.right);
			else if (selectedAxis.name == "Y")
				selectedSphere.transform.localRotation = selectedSphere.transform.localRotation * Quaternion.AngleAxis (30f * y, Vector3.up);
			else if (selectedAxis.name == "Z")
				selectedSphere.transform.localRotation = selectedSphere.transform.localRotation * Quaternion.AngleAxis (30f * x, Vector3.forward);
		}

	
	}

}
