using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour
{
	public float red;
	public float green;
	public float blue;
	public float redLight;
	private float remainderRed;
	public float greenLight;
	private float remainderGreen;
	public float blueLight;
	private float remainderBlue;
	private float redHint;
	private float colourDiff = 0.02f;
	public GameObject[] floors;
    private Renderer[] floorRenderers;
	private int hintCount = 4;
	private int hintRand;

	private GameObject mainCamera;
	private GameObject player;
	private bool disableCamera;
	private int camCount = 330;
	public bool vaultOpen = false;
	public Camera vaultCamera;
	private GameObject vault;

	private GameObject[] buttons;

	void Start ()
    {
		buttons = GameObject.FindGameObjectsWithTag("Button");
		floors = GameObject.FindGameObjectsWithTag("Floor");
        floorRenderers = new Renderer[floors.Length];

        for (int i = 0; i < floors.Length; i++)
            floorRenderers[i] = floors[i].GetComponent<Renderer>();

		vault = GameObject.FindGameObjectWithTag("VaultMain");
		vaultCamera.GetComponent<Camera>().enabled = false;
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag("Player");

		blueLight = Random.Range (0.05f, 1f);
		remainderBlue = ((blueLight * 100) % 5);
		if (remainderBlue > 0)
			blueLight = (((blueLight * 100)-remainderBlue)/100);

		redLight = Random.Range (0.05f, 1f);
		remainderRed = ((redLight * 100) % 5);
		if (remainderRed > 0)
			redLight = (((redLight * 100) - remainderRed) / 100);

		greenLight = Random.Range (0.05f, 1f);
		remainderGreen = ((greenLight * 100) % 5);
		if (remainderGreen > 0) 
			greenLight = (((greenLight * 100) - remainderGreen) / 100);

		vault.GetComponent<Renderer>().material.color = new Color(redLight, greenLight, blueLight, 0);
	}

    void UpdateColours()
    {
        foreach (Renderer renderer in floorRenderers)
            renderer.material.color = new Color(red, green, blue, 0);

        if ((red >= redLight - colourDiff) && (red <= redLight + colourDiff))
        {
            if ((green >= greenLight - colourDiff) && (green <= greenLight + colourDiff))
            {
                if ((blue >= blueLight - colourDiff) && (blue <= blueLight + colourDiff))
                {
                    if (camCount > 0)
                    {
                        camCount -= 1;
                        VaultOpen();
                        vaultOpen = true;
                    }
                    else
                    {
                        player.SetActive(true);
                        mainCamera.GetComponent<Camera>().enabled = true;
                        mainCamera.GetComponent<AudioListener>().enabled = true;
                        vaultCamera.GetComponent<AudioListener>().enabled = false;
                        vaultCamera.GetComponent<Camera>().enabled = false;
                    }
                }
            }
        }
    }

    public void SetColourValue(ButtonInfo.Colour colour, ButtonInfo.Size size)
    {
        float[] sizes = new float[3] { 0.05f, 0.1f, 0.2f };
        switch (colour)
        {
            case ButtonInfo.Colour.RED:
                red = Mathf.Clamp(red + sizes[(int)size], 0.0f, 1.0f);
                break;
            case ButtonInfo.Colour.GREEN:
                green = Mathf.Clamp(green + sizes[(int)size], 0.0f, 1.0f);
                break;
            case ButtonInfo.Colour.BLUE:
                blue = Mathf.Clamp(blue + sizes[(int)size], 0.0f, 1.0f);
                break;
        }
        Debug.Log("set colour value");
        UpdateColours();
    }

    public void ResetColourValue(ButtonInfo.Colour colour)
    {
        switch (colour)
        {
            case ButtonInfo.Colour.RED:
                red = 0.0f;
                break;
            case ButtonInfo.Colour.GREEN:
                green = 0.0f;
                break;
            case ButtonInfo.Colour.BLUE:
                blue = 0.0f;
                break;
        }
        UpdateColours();
    }
    
	public void Reset()
    {
		red = 0f;
		green = 0f;
		blue = 0f;
		hintCount = 4;
        UpdateColours();
	}

	public void Hint()
    {
		if (red > 0.0f && blue > 0.0f && green > 0.0f)
        {
			if (hintCount >= 0)
            {
				hintCount -= 1;
				hintRand = Random.Range (1, 4);
				if (hintRand == 1)
					Debug.LogFormat("{0}: {1} hints remaining.", red - redLight, hintCount);
				else if (hintRand == 2)
                    Debug.LogFormat("{0}: {1} hints remaining.", green - greenLight, hintCount);
				else
                    Debug.LogFormat("{0}: {1} hints remaining.", blue - blueLight, hintCount);
            }
            else
				print("No hints remaining, hit reset to try again!");
		}
        else
			print ("What are you trying to do, cheat?");
    }

	void VaultOpen()
    {
		GetComponent<BoxCollider> ().isTrigger = true;
		mainCamera.GetComponent<Camera>().enabled = false;
		mainCamera.GetComponent<AudioListener>().enabled = false;
		vaultCamera.GetComponent<AudioListener>().enabled = true;
		vaultCamera.GetComponent<Camera>().enabled = true;

		player.SetActive(false);
		foreach(GameObject button in buttons)
			Destroy(button);

		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.03f, transform.position.z);
	}
}