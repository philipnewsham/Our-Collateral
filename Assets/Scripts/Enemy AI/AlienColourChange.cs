using UnityEngine;
using System.Collections;

public class AlienColourChange : MonoBehaviour
{
	private bool alarmed = false;
	private int randNo;
	private ParticleSystem ptcl;

	void Start ()
    {
		ptcl = GetComponent<ParticleSystem> ();
	}

    public void SetAlarmState(bool alarmState)
    {
        alarmed = alarmState;
    }
	
	void Update ()
    {
		randNo = Random.Range (1,3);
        //if alarmed random between red (1,0,0,1) or yellow (1,1,0,1)
        //if not alarmed random between cyan (0,1,1,1) or blue (0,0,1,1)
		ptcl.startColor = new Color ((alarmed ? 1 : 0), (randNo == 1 ? 0 : 1), (alarmed ? 0 : 1), 1);
	}
}