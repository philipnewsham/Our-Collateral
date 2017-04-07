using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	public GameObject key;
	public float turnY;
	public bool unlocked = false;
	public bool reverse;
	float speed = 2f;
	public bool keyModel;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	if (reverse) {
			speed *= -1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if((keyModel)&&(unlocked)){
			Destroy(gameObject);
		}

		if (!reverse) {
			if ((unlocked) && (turnY < 90)) {
				transform.Rotate (new Vector3 (0, 0, 1f) * speed);
				turnY += speed;
			}
		} else {
			if ((unlocked) && (turnY < 90)) {
				transform.Rotate (new Vector3 (0, 0, 1f) * speed);
				turnY -= speed;
			}else{

				audioSource.Stop ();
			}
		}
	}
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			if(key == null){
				unlocked = true;
				if(reverse){
					audioSource.pitch = .85f;
					audioSource.Play ();
				}
			}
		}
	}
}
