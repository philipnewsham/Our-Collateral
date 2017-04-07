using UnityEngine;
using System.Collections;

public class TeleporterScript01 : MonoBehaviour {
	public Collider otherTeleporter;
	public Transform tele1;
	public Transform tele2;

	private GameObject player;
	private Transform playerTransform;
	private float xDiff;
	private float zDiff;
	private float yDiff;
	private int count;

	void Start(){
		count = 20;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.GetComponent<Transform> ();
	}

	void Update(){
		if (GetComponent<Collider> ().enabled == false) {
			count -= 1;
			if(count <= 0){
				GetComponent<Collider>().enabled = true;
				count = 20;
			}
		}
	}

void OnTriggerEnter (Collider target){

		if ((target.gameObject.tag == "Player")) {
			otherTeleporter.enabled = false;
			GetComponent<Collider>().enabled = false;
			//Debug.LogFormat("trigger {0}", name);
			//math time!

			xDiff = tele1.position.x - playerTransform.position.x;
			yDiff = tele1.position.y - playerTransform.position.y;
			zDiff = tele1.position.z - playerTransform.position.z;
			//moves player to new teleport
				playerTransform.position = new Vector3 (tele2.position.x - xDiff, tele2.position.y - yDiff, tele2.position.z - zDiff);
		}
	}
}