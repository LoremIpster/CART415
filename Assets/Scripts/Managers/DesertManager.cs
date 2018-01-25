using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertManager : MonoBehaviour {

	public Canvas canvas;
	public GameObject headlights;
	public AudioSource engine;
	public bool controlsOn;

	void Start () {
		headlights.SetActive (false);
		engine.enabled = false;	
	}
	
	void Update () {
		if(Input.anyKey){
			canvas.gameObject.SetActive (false);
			StartCoroutine (Intro());
	}
}

	IEnumerator Intro(){
		yield return new WaitForSeconds(2);
		engine.enabled = true;
		yield return new WaitForSeconds(2);
		headlights.SetActive (true);
		yield return new WaitForSeconds(1);
		controlsOn = true;
	}
}