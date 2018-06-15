using UnityEngine;
using System.Collections;

public class ForceFieldScript : MonoBehaviour
{
	void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Player")
			GetComponent<AudioSource>().Play();
	}
}
