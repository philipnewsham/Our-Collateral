using UnityEngine;
using System.Collections;

public class SlowRotate : MonoBehaviour
{
	public float speed;

	void FixedUpdate ()
    {
		transform.Rotate (Vector3.up * speed);
	}
}
