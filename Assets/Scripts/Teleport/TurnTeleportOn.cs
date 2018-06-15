using UnityEngine;
using System.Collections;

public class TurnTeleportOn : MonoBehaviour
{
	public GameObject teleporterCollider;

	void OnTriggerExit(Collider other)
    {
		teleporterCollider.GetComponent<Collider>().enabled = true;
	}

}
