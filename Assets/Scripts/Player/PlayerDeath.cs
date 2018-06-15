using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDeath : MonoBehaviour
{
	private Camera cam;
	public FirstPersonController script;
	public bool dead = false;
	public GameObject deathText;
	public GameObject timeOutText;
	public GameObject countdown;
	CountingDownScript countdownScript;
	bool outOfTime;

	void Start()
    {
		countdownScript = countdown.GetComponent<CountingDownScript> ();
	}

	void Update()
    {
		outOfTime = countdownScript.outOfTime;

		if (outOfTime)
        {
			Dead();
			timeOutText.SetActive(true);
		}

		if(Input.GetKey (KeyCode.R) && dead)
        {
			Application.LoadLevel (0);
		}
	}

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Enemy")
        {
			Dead();
			deathText.SetActive(true);
		}
	}

	void Dead()
    {
		script.enabled = false;
		cam = GetComponentInChildren<Camera>();
		cam.cullingMask = 0;
		cam.cullingMask = 6;
		dead = true;
		print ("Press R to Restart");
	}
}
