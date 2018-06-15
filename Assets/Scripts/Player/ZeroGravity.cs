using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ZeroGravity : MonoBehaviour
{
	public FirstPersonController script;
	public float gravityMultiplier;

	void Start ()
    {
		script = GetComponent<FirstPersonController> ();
		gravityMultiplier = script.m_GravityMultiplier;
	}

	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Space")
        {
			print ("inspace");
			gravityMultiplier = 0.5f;
		}
	}

	void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "Space")
        {
			gravityMultiplier = 2f;
		}
	}
}