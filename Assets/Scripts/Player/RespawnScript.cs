using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {
	public Transform respawnPoint;
	private GameObject player;
	private Transform playerTransform;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			playerTransform.position = new Vector3 (respawnPoint.position.x,respawnPoint.position.y,respawnPoint.position.z);
		}
	}
}
