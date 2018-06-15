using UnityEngine;
using System.Collections;

public class LightArrange : MonoBehaviour
{
	public float posY;
	void Start ()
    {
		transform.position = new Vector3(transform.position.z,posY,transform.position.z);
	}
}
