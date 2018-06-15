using UnityEngine;
using System.Collections;

public class PlayerTeleport : MonoBehaviour
{
	public Transform teleportLocation;
	public float speed;

	private float teleX;
	private float teleY;
	private float teleZ;


	void Start()
    {
		speed = 0.05f;
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		teleX = teleportLocation.position.x;
		teleY = teleportLocation.position.y;
		teleZ = teleportLocation.position.z;
	}

	void Update()
    {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
	}

	void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Teleport")
        {
			speed *= -1;
			transform.localRotation = new Quaternion (transform.localRotation.x, teleportLocation.localRotation.y,transform.localRotation.z, transform.localRotation.w);
			transform.position = new Vector3 (teleX,teleY,teleZ);
		}
	}
}