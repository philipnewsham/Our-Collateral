using UnityEngine;
using System.Collections;

public class AlienColourChange : MonoBehaviour {
	public bool alarmed = false;
	private int randNo;
	private ParticleSystem ptcl;
	// Use this for initialization
	void Start () {
		ptcl = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		randNo = Random.Range (1,3);
		if (alarmed == true) {
			//Alarm();
			if(randNo == 1){
				ptcl.startColor = new Color (1, 0, 0, 1);
			}else{
				ptcl.startColor = new Color (1, 1, 0, 1);
			}
		} else {
			if(randNo == 1){
				ptcl.startColor = new Color (0, 0, 1, 1);
			}else{
				ptcl.startColor = new Color (0, 1, 1, 1);
			}
		}
	}
//	void Alarm(){
//		ptcl.startColor[0] = new Color (1, 0, 0, 1);
//		ptcl.startColor[1] = new Color (1, 1, 0, 1);
//	}
}
