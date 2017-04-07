﻿using UnityEngine;
using System.Collections;

public class LockedHand : MonoBehaviour {

	private GameObject vault;
	private Colour colourScript;
	private float redVault;
	private float greenVault;
	private float blueVault;
	
	private float redFloor;
	private float greenFloor;
	private float blueFloor;
	
	public float redPercentage;
	public float greenPercentage;
	public float bluePercentage;
	public float lockPercentage;
	
	public bool unlocked = false;
//	bool entered = false;
	public bool red;
	public bool green;
	public bool blue;
	// Use this for initialization
	void Start () {
		vault = GameObject.FindGameObjectWithTag ("Vault");
		colourScript = vault.GetComponent<Colour> ();
	}
	
	void Update(){
		redVault = colourScript.redLight;
		greenVault = colourScript.greenLight;
		blueVault = colourScript.blueLight;
		
		redFloor = colourScript.red;
		greenFloor = colourScript.green;
		blueFloor = colourScript.blue;
		
		//maths
		redPercentage = (((redVault - redFloor)/redVault)*100);
		if (redFloor > redVault) {
			redPercentage = 100 + redPercentage;
		} else {
			redPercentage = 100 - redPercentage;
		}
		
		greenPercentage = (((greenVault - greenFloor)/greenVault)*100); 
		if (greenFloor > greenVault) {
			greenPercentage = 100 + greenPercentage;
		} else {
			greenPercentage = 100 - greenPercentage;
		}
		
		bluePercentage = (((blueVault - blueFloor)/blueVault)*100); 
		if (blueFloor > blueVault) {
			bluePercentage = 100 + bluePercentage;
		} else {
			bluePercentage = 100 - bluePercentage;
		}
		lockPercentage = Mathf.RoundToInt((redPercentage + greenPercentage + bluePercentage)/3);

		if (red) {
			if (redPercentage < 0) {
				transform.rotation = Quaternion.Euler ((0), 0, 0);
			} else {
				transform.rotation = Quaternion.Euler ((redPercentage * 1.8f), 0, 0);
			}
		}
		if (green) {
			if (greenPercentage < 0) {
				transform.rotation = Quaternion.Euler ((0), 0, 0);
			} else {
				transform.rotation = Quaternion.Euler ((greenPercentage * 1.8f), 0, 0);
			}
		}
		if (blue) {
			if (bluePercentage < 0) {
				transform.rotation = Quaternion.Euler ((0), 0, 0);
			} else {
				transform.rotation = Quaternion.Euler ((bluePercentage * 1.8f), 0, 0);
			}
		}

		if ((!red) && (!green) && (!blue)) {
			if (lockPercentage < 0) {
				transform.rotation = Quaternion.Euler ((0), 0, 0);
			} else {
				transform.rotation = Quaternion.Euler ((lockPercentage * 1.8f), 0, 0);
			}
		}
		if (lockPercentage == 100) {
			unlocked = true;
		}
		
	}
	
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			if (unlocked == false) {
				GetComponent<TextMesh> ().text = ("Escape \n Pod \n Unlock: " + lockPercentage + "%");
			} else {
				GetComponent<TextMesh> ().text = " ";
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {

		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
		}
	}
}
