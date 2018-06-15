using UnityEngine;
using System.Collections;

public class FloorSpotColours : MonoBehaviour
{
	public bool redSpot;
	public bool greenSpot;
	public bool blueSpot;
	
	private GameObject vault;
	private Colour colourScript;
	
	private float redFloor;
	private float greenFloor;
	private float blueFloor;
	
	void Start ()
    {
		vault = GameObject.FindGameObjectWithTag ("Vault");
		colourScript = vault.GetComponent<Colour> ();
	}
	
	void Update ()
    {
		redFloor = colourScript.red;
		greenFloor = colourScript.green;
		blueFloor = colourScript.blue;

		if ((redSpot == true)&&(greenSpot == false)&&(blueSpot == false))
			GetComponent<Renderer> ().material.color = new Color (redFloor, 0, 0, 1);

		if ((greenSpot == true)&&(redSpot == false)&&(blueSpot == false))
			GetComponent<Renderer> ().material.color = new Color (0, greenFloor, 0, 1);

		if ((blueSpot == true)&&(greenSpot == false)&&(redSpot == false))
			GetComponent<Renderer> ().material.color = new Color (0, 0, blueFloor, 1);

		if ((redSpot == true) && (greenSpot == true))
			GetComponent<Renderer> ().material.color = new Color (redFloor, greenFloor, 0, 1);

		if ((redSpot == true) && (blueSpot == true))
			GetComponent<Renderer> ().material.color = new Color (redFloor, 0, blueFloor, 1);

		if ((greenSpot == true) && (blueSpot == true))
			GetComponent<Renderer> ().material.color = new Color (0, greenFloor, blueFloor, 1);
	}
}
