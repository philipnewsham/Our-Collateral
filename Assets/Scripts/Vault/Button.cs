using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	public float colourSpeed;
	public float blue;
	public bool blueButton;
	public float red;
	public bool redButton;
	public float green;
	public bool greenButton;
	private GameObject vault;
	private bool enter = false;
	public bool buttonHalf;
	public bool buttonSingle;
	public bool buttonDouble;
	public bool buttonReset;
	public bool vaultOpen;
	AudioSource audioS;

    void Start()
    {
		vault = GameObject.FindGameObjectWithTag ("Vault");
		audioS = GetComponent<AudioSource> ();
	}

	void Update()
    {
		vaultOpen = vault.GetComponent<Colour> ().vaultOpen;

		if (vaultOpen == true)
        {
			GetComponent<Button>().enabled = false;
			GetComponent<MeshRenderer>().enabled = false;
		}

		if (Input.GetKeyUp (KeyCode.E))
        {
			enter = false;
		}
	}

	void OnTriggerStay(Collider other)
    {
		if ((other.gameObject.tag == "Player"))
        {
			if(Input.GetKeyDown(KeyCode.E) && !enter)
            {
				enter = true;
			    if(buttonHalf == true)
                {
					audioS.pitch = 1.5f;
			        if (blueButton == true)
				        vault.GetComponent<Colour>().Blue1();
                    else if (redButton == true)
				        vault.GetComponent<Colour>().Red1();
                    else if (greenButton == true)
				        vault.GetComponent<Colour>().Green1();
			    }

			    if(buttonSingle == true)
                {
					audioS.pitch = 1f;
				    if (blueButton == true) {
					vault.GetComponent<Colour>().Blue2();
				    } else if (redButton == true) {
					vault.GetComponent<Colour>().Red2();
				    } else if (greenButton == true) {
					vault.GetComponent<Colour>().Green2();
				    }
			    }

			    if(buttonDouble == true)
                {
					audioS.pitch = 0.5f;
				    if (blueButton == true)
					    vault.GetComponent<Colour>().Blue4();
				    else if (redButton == true)
					    vault.GetComponent<Colour>().Red4();
				    else if (greenButton == true)
					    vault.GetComponent<Colour>().Green4();
			    }

			    if(buttonReset == true)
                { 
				    if (blueButton == true) 
					    vault.GetComponent<Colour>().BlueReset();
				    else if (redButton == true) 
					    vault.GetComponent<Colour>().RedReset();
				    else if (greenButton == true) 
					    vault.GetComponent<Colour>().GreenReset();
				}
			}
			GetComponent<AudioSource>().Play();
		}
	}

	void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "Player")
			enter = false;
	}
}