using UnityEngine;
using System.Collections;

public class AlienNeutral : MonoBehaviour
{
	public GameObject lockGameObject;
	private LockedHand lockScript;
	public GameObject playerChecker;
	public bool unlocked;
	private ParticleSystem ptcl;

	void Start ()
    {
		lockScript = lockGameObject.GetComponent<LockedHand> ();
		unlocked = lockScript.unlocked;
		ptcl = GetComponent<ParticleSystem> ();
	}
	
	void Update ()
    {
		unlocked = lockScript.unlocked;
		if (unlocked)
        {
			gameObject.tag = "Untagged";
			Destroy(playerChecker);
			int randNo = Random.Range (1,3);
            //random colour between dark green and green
            ptcl.startColor = randNo == 1 ? new Color(0, 0.2f, 0.05f, 1f) : new Color(0, 1, 0, 1);
		}

	}
}
