using UnityEngine;
using System.Collections;

public class EscapeWheel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			if(Input.GetKeyDown (KeyCode.E)){
				//print ("complete");
				Application.LoadLevel(3);
			}
		}

	}
}
