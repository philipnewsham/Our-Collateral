using UnityEngine;
using System.Collections;

public class EscapeWheel : MonoBehaviour
{
	void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
			if(Input.GetKeyDown (KeyCode.E))
				Application.LoadLevel(3);
		}
	}
}