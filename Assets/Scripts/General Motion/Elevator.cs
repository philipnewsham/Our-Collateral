using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public Transform elevatorTop;
	public Transform elevatorBottom;

	public float speed;

	public bool stopped = true;
	// Use this for initialization
	void Start () {
		speed = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (((transform.position.y >= elevatorTop.position.y ) || (transform.position.y <= elevatorBottom.position.y))&&(stopped == false)) {
			speed = 0;
			stopped = true;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if (stopped == true) {
				ElevatorGo ();
			}
		}
	}
//		void OnTriggerExit(Collider other){
//			if (other.gameObject.tag == "Player") {
//				speed = 0f;
//			}
//	}

	void ElevatorGo(){
		if (transform.position.y >= elevatorBottom.position.y){
			speed = -0.05f;
		}

		   if (transform.position.y <= elevatorTop.position.y) {
			speed = 0.05f;
		}
		stopped = false;
	}
}
