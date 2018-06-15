using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour
{
	private float posY;
	private float speed = 0.005f;
	private float hoverRange = 0.25f;
	
	void Start ()
    {
		posY = transform.position.y;
	}

	void FixedUpdate ()
    {
		if (transform.position.y > posY + hoverRange || transform.position.y < posY - hoverRange)
			speed *= -1;

		transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
	}
}