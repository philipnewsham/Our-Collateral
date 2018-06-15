using UnityEngine;
using System.Collections;

public class PlayerCheckerTurnOn : MonoBehaviour
{
	public float count;
	
	void Update ()
    {
		count -= 1 * Time.deltaTime;
		if (count < 0)
			GetComponent<SphereCollider>().enabled = true;
	}
}