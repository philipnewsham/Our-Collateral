using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
			GetComponent<AudioSource>().Play ();
			Destroy(gameObject, 0.5f);
		}
	}
}