using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float turnSpeed;

	private float posX;
	private float posZ;
	
	void Start () {
		posX = transform.position.x;
		posZ = transform.position.z;
	}

	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			posZ += speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			posZ -= speed;
		}
		if (Input.GetKey (KeyCode.A)) {
			posX += speed;
			transform.Rotate(Vector3.up * turnSpeed);
		}
		if (Input.GetKey (KeyCode.D)) {
			posX -= speed;
			transform.Rotate(Vector3.down * turnSpeed);
		}
		transform.localPosition = new Vector3 (posX, transform.position.y, posZ);
	}
}
