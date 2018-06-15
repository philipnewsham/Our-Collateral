using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour
{
	public Transform respawnPoint;
	private GameObject player;
	private Transform playerTransform;

	void Start ()
    {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.GetComponent<Transform> ();
	}

	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.tag == "Player")
			playerTransform.position = new Vector3 (respawnPoint.position.x,respawnPoint.position.y,respawnPoint.position.z);
	}
}
