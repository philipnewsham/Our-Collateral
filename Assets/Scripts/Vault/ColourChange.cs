using UnityEngine;
using System.Collections;

public class ColourChange : MonoBehaviour
{
	private Light lt;
	public float red;
	public float blue;
	public float green;

	public GameObject[] buttons;
	public Button buttonScript;

	private int i;

	void Start ()
    {
		lt = GetComponent<Light> ();
		buttons = GameObject.FindGameObjectsWithTag ("Button");
		CheckColour ();
	}

	void CheckColour()
    {
		for (i = 0; i < buttons.Length; i ++)
        {
			if (red > 1) 
				red = 1;
            
			if (blue > 1) 
				blue = 1;
			
			if (green > 1) 
				green = 1;
			
			lt.color = new Color (red, green, blue, 1);
		}
	}
}