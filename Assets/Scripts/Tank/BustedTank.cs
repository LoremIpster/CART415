using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustedTank : MonoBehaviour {

	public Canvas canvas;

	void Start () {



	}

	private void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Tank") {
			canvas.gameObject.SetActive (false);
			Debug.Log ("out of range!");
		} else {
			canvas.gameObject.SetActive (true);
		}
	}

	private void OnTriggerExit(Collider other){
	
	}
}
