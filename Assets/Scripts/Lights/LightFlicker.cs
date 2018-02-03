using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	public float minFlickerSpeed = 0.1f;
	public float maxFlickerSpeed = 1.2f;

	private float randomTimer;

	void Start () {
		
	}
		
	void Update () {
		while (true) {
			if (randomTimer == 0.1f) {
				gameObject.SetActive (false);
			} else {
				gameObject.SetActive (true);
				randomTimer = Random.Range (minFlickerSpeed, maxFlickerSpeed);
			}

		}
		
	}

	//StartCoroutine (Flicker());
	/*
	IEnumerator Flicker(){
		gameObject.SetActive (true);
		yield return new WaitForSeconds((Random.Range(minFlickerSpeed, maxFlickerSpeed)));
		gameObject.SetActive (false);
		yield return new WaitForSeconds((Random.Range(minFlickerSpeed, maxFlickerSpeed)));
	}
	*/
}
