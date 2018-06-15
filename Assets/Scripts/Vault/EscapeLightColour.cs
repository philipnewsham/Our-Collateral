using UnityEngine;
using System.Collections;

public class EscapeLightColour : MonoBehaviour
{
	private Light lt;
	private float red;
	private float blue;
	private float green;

	public Light ltX;
	private ColourChange ltXScript;
	private float redX;
	private float blueX;
	private float greenX;

	void Start()
    {
		ChooseLightColour();
		ltXScript = ltX.GetComponent<ColourChange>();
		redX = ltXScript.red;
		blueX = ltXScript.blue;
		greenX = ltXScript.green;
	}

	void Update()
    {
		if ((redX >= red - 0.05f) && (redX <= red + 0.05f))
        {
			if ((blueX >= blue - 0.05f) && (blueX <= blue + 0.05f))
            {
				if ((green >= greenX - 0.05f) && (greenX <= green + 0.05f))
					print ("Escape");
			}
		}
	}

	void ChooseLightColour()
    {
		lt = GetComponent<Light> ();
		red = Random.Range (0.01f, 0.99f);
		blue = Random.Range (0.01f, 0.99f);
		green = Random.Range (0.01f, 0.99f);
		lt.color = new Color(red, green, blue, 1);
	}
}