using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public GameObject tank;

	private void OnTriggerExit(Collider other){
		Destroy (tank);
		Debug.Log ("BOY BYE");
	}
}
