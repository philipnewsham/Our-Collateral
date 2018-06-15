using UnityEngine;
using System.Collections;

public class HintSystem : MonoBehaviour
{
	public GameObject[] thoughts;
	public GameObject[] countDownImages;
	public int currentThought;
	public int importantThought;

	public GameObject[] keyCards;
	public GameObject[] keyCardImages;

	public GameObject keycard;
	public bool cardGet;
	public bool closeCall = false;
	public bool threeMins = false;
	public bool tenMins = false;
	private bool button = false;
	private bool numbers = false;
	private bool space = false;
	private bool collateral = false;
	bool doorcheck = false;
	bool bridge = false;
	bool escapePod = false;
	bool engine = false;
	bool alien = false;
	public float count = 180;
	public float secondCount = 0;
	public float minuteCount = 0;

	public GameObject hintSource;
	private AudioSource audioS;

	PlayerDeath deathScript;
	bool dead;

	void Start ()
    {
		currentThought = 0;
		importantThought = currentThought;
		audioS = hintSource.GetComponent<AudioSource> ();
		deathScript = GetComponent<PlayerDeath> ();
	}

	void FixedUpdate()
    {
		if (closeCall)
        {
			count -= 1;
			if (count < 0)
            {
				closeCall = false;
				currentThought = importantThought;
			}
		}
	}

	void Update ()
    {
		dead = deathScript.dead;
	
		if (!dead)
        {
			if (Input.GetKeyDown (KeyCode.Tab))
            {
				thoughts [currentThought].SetActive (true);
				for (int j = 0; j < countDownImages.Length; j++)
                {
					countDownImages [j].SetActive (true);
				}
				for (int x = 0; x < keyCards.Length; x++)
                {
					if(keyCards[x] == null)
                    {
						keyCardImages [x].SetActive (true);
					}
				}
			}
            else if (Input.GetKeyUp (KeyCode.Tab))
            {
				for (int i = 0; i < thoughts.Length; i++)
                {
					thoughts [i].SetActive (false);
				}
				for (int j = 0; j < countDownImages.Length; j++)
                {
					countDownImages [j].SetActive (false);
				}
				for (int x = 0; x < keyCards.Length; x++)
                {
						keyCardImages [x].SetActive (false);
				}
			}

			if (keycard == null && !cardGet)
            {
				cardGet = true;
				currentThought = 3;
				audioS.Play ();
			}

			if (minuteCount >= 2 && !threeMins)
            {
				threeMins = true;
				currentThought = 5;
				audioS.Play ();
			}

			if (minuteCount >= 10 && !tenMins)
            {
				tenMins = true;
				currentThought = 10;
				audioS.Play ();
			}

			secondCount += 1f * Time.deltaTime;
			if (secondCount > 3599)
            {
				minuteCount += 1;
				secondCount = 0;
			}
		}
        else
        {
			for (int i = 0; i < thoughts.Length; i++)
            {
				thoughts [i].SetActive (false);
			}

			for (int j = 0; j < countDownImages.Length; j++)
            {
				countDownImages [j].SetActive (false);
			}
		}
	}

	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Engine")
        {
			if(!engine)
            {
				audioS.Play ();
				engine = true;
			}
			currentThought = 15;
		}

		if (other.gameObject.tag == "Escape")
        {
			if(!escapePod)
            {
				escapePod = true;
			    audioS.Play ();
			    currentThought = 13;
			}
			importantThought = 14;
		}

		if (other.gameObject.tag == "Door")
        {
			if ((keycard != null)&&(!doorcheck))
            {
				doorcheck = true;
				audioS.Play ();
			}
		}

		if (other.gameObject.tag == "Numbers" && !numbers)
        {
			audioS.Play ();
			numbers = true;
		}
		
		if (other.gameObject.tag == "Collateral" && !collateral)
        {
			audioS.Play ();
			collateral = true;
		} 
		
		if (other.gameObject.tag == "Space" && !space)
        {
			audioS.Play ();
			space = true;
		}
		
	}
	void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Bridge")
        {
			if(!bridge)
            {
				audioS.Play ();
				bridge = true;
			    importantThought = currentThought;
			}
			currentThought = 12;
		}

		if (other.gameObject.tag == "Door")
        {
			if (keycard != null)
            {
				currentThought = 1;
				importantThought = 2;
			}
		}

		if (other.gameObject.tag == "Button" && !button)
        {
			if (Input.GetKeyDown (KeyCode.E))
            {
				currentThought = 6;
				audioS.Play ();
				importantThought = 7;
				button = true;
			}
		}

		if (other.gameObject.tag == "Numbers")
        {
			importantThought = 8;
			currentThought = importantThought;
		}

		if (other.gameObject.tag == "Collateral")
        {
			currentThought = 11;
		} 

		if (other.gameObject.tag == "Space")
        {
			currentThought = 9;
		}
	}

	void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "Engine")
        {
			currentThought = importantThought;
		}

		if (other.gameObject.tag == "Escape")
        {
			currentThought = importantThought;
		}

		if (other.gameObject.tag == "Bridge")
        {
			currentThought = importantThought;
		}

		if (other.gameObject.tag == "Door")
        {
			if(keycard != null)
            {
				currentThought = importantThought;
			}
		}

		if (other.gameObject.tag == "Checker")
        {
			closeCall = true;
			currentThought = 4;
			if (!alien)
            {
				alien = true;
				audioS.Play ();
			}
		}

		if (other.gameObject.tag == "Button")
        {
			currentThought = importantThought;
		}

		if (other.gameObject.tag == "Space")
        {
			currentThought = importantThought;
		}

		if (other.gameObject.tag == "Collateral")
        {
			currentThought = importantThought;
		}
	}
}