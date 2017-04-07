using UnityEngine;
using System.Collections;

public class AlienNeutral : MonoBehaviour {
	public GameObject lockGameObject;
	LockedHand lockScript;
	public GameObject playerChecker;
	public bool unlocked;
	private ParticleSystem ptcl;
	// Use this for initialization
	void Start () {
		lockScript = lockGameObject.GetComponent<LockedHand> ();
		unlocked = lockScript.unlocked;
		ptcl = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		unlocked = lockScript.unlocked;
		if (unlocked) {
			gameObject.tag = "Untagged";
			Destroy (playerChecker);
			int randNo = Random.Range (1,3);
			if(randNo == 1){
				ptcl.startColor = new Color (0, .2f, .05f, 1);
			}else{
				ptcl.startColor = new Color (0, 1, 0, 1);
			}
		}

	}
}
