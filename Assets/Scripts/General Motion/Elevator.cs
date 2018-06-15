using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
	public Transform elevatorTop;
	public Transform elevatorBottom;
	public float speed;
	public bool stopped = true;

	void Start ()
    {
		speed = 0f;
	}
	
	void FixedUpdate ()
    {
		if ((transform.position.y >= elevatorTop.position.y || transform.position.y <= elevatorBottom.position.y) && !stopped)
        {
			speed = 0;
			stopped = true;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
	}

	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player" && stopped)
			ElevatorGo ();
	}

	void ElevatorGo()
    {
		if (transform.position.y >= elevatorBottom.position.y)
			speed = -0.05f;

		if (transform.position.y <= elevatorTop.position.y)
			speed = 0.05f;

		stopped = false;
	}
}