using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryManager : MonoBehaviour {

	public Canvas canvas;
	private GameObject headlights;
	private AudioSource engine;
	private TankMovement_Desert tankScript;

	void Start () {
		headlights.SetActive (false);
		engine.enabled = false;	
	}
	
	void Update () {
		if(Input.anyKey){
			//canvas.gameObject.SetActive (false);
			StartCoroutine (Intro());
	}
}

	IEnumerator Intro(){
		yield return new WaitForSeconds(2);
		canvas.gameObject.SetActive (false);
		engine.enabled = true;
		yield return new WaitForSeconds(2);
		headlights.SetActive (true);
		yield return new WaitForSeconds(1);
		tankScript.controlsOn = true;
	}
}