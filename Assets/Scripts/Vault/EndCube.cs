using UnityEngine;
using System.Collections;

public class EndCube : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
			Application.LoadLevel (0);
	}
}