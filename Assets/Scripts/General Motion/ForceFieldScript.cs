using UnityEngine;
using System.Collections;

public class ForceFieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("hit");
			GetComponent<AudioSource>().Play ();
		}
	}
}
