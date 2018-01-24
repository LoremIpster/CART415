using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustedTank : MonoBehaviour {

	public Canvas canvas;

	void Start () {



	}

	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Tank") {
			//Debug.Log ("COLLLLL");
			canvas.gameObject.SetActive (true);
		} else {
			//canvas.gameObject.SetActive (false);
		}
	}
}
