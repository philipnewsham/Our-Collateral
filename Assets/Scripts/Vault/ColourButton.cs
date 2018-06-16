using UnityEngine;
using System.Collections;

public static class ButtonInfo
{
    public enum Size
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    public enum Colour
    {
        RED,
        GREEN,
        BLUE
    }
}

public class ColourButton : MonoBehaviour
{
	private GameObject vault;
    private Colour colourScript;
	private bool enter = false;
	public bool buttonReset;
	public bool vaultOpen;
	AudioSource audioSource;
    public ButtonInfo.Size buttonSize;
    public ButtonInfo.Colour buttonColour;

    void Start()
    {
		vault = GameObject.FindGameObjectWithTag("Vault");
		audioSource = GetComponent<AudioSource>();
        colourScript = vault.GetComponent<Colour>();
        StartCoroutine(WaitForUnlock());
	}

	void Update()
    {
		if (Input.GetKeyUp (KeyCode.E))
			enter = false;
	}

    IEnumerator WaitForUnlock()
    {
        yield return new WaitUntil(() => colourScript.vaultOpen);
        GetComponent<MeshRenderer>().enabled = false;
        this.enabled = false;
    }

	void OnTriggerStay(Collider other)
    {
		if ((other.gameObject.tag == "Player"))
        {
			if(Input.GetKeyDown(KeyCode.E) && !enter)
            {
				enter = true;
                if (buttonReset)
                    colourScript.ResetColourValue(buttonColour);
                else
                    colourScript.SetColourValue(buttonColour, buttonSize);
                audioSource.Play();
            }
		}
	}

	void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "Player")
			enter = false;
	}
}