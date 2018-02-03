using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustedTank : MonoBehaviour {

	public Canvas canvas;
	private float timeStill;
	public float mournDuration = 3f;
	private bool isMournComplete;
	private bool isTimerOn;

	void Update () {
		Debug.Log (timeStill);
		if (isTimerOn) {
			Timer ();
		}
	}

	private void Timer(){
		timeStill += Time.deltaTime;
		if (timeStill >= mournDuration) {
			isMournComplete = true;
		}
	}

	private void OnTriggerEnter(Collider other){
		//Debug.Log ("ENTER");
		canvas.gameObject.SetActive (true);
		isTimerOn = true;
	}

	private void OnTriggerExit(Collider other){
		//Debug.Log ("EXIT");
		canvas.gameObject.SetActive (false);
		timeStill = 0;
		isTimerOn = false;
		if (isMournComplete) {
			Destroy (gameObject);
		}
	}

	/*
	private void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Tank") {
			canvas.gameObject.SetActive (true);
			timeStill += Time.deltaTime;
			if(timeStill >= mournDuration){
				mournComplete = true;
			}
		} else {
			canvas.gameObject.SetActive (false);
			timeStill = 0;
		}
	}
	*/
		
}
