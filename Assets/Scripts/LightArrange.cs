﻿using UnityEngine;
using System.Collections;

public class LightArrange : MonoBehaviour {
	public float posY;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.z,posY,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
