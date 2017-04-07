﻿using UnityEngine;
using System.Collections;

public class ResetText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = " ";
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			GetComponent<TextMesh> ().text = "X";
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			GetComponent<TextMesh> ().text = " ";
		}
	}
}
