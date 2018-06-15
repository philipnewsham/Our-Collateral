using UnityEngine;
using System.Collections;

public class GetNumber : MonoBehaviour
{
	private GameObject vault;
	private Colour colourScript;
	private float redVault;
	private float greenVault;
	private float blueVault;

	TextMesh textMesh;

	private float redFloor;
	private float greenFloor;
	private float blueFloor;

	public bool vaultNumber;

	public bool red;
	public bool green;
	public bool blue;
	public bool floorNumber;
    
	void Start ()
    {
		vault = GameObject.FindGameObjectWithTag ("Vault");
		colourScript = vault.GetComponent<Colour> ();
		textMesh = GetComponent<TextMesh> ();
		textMesh.text = " ";
	}
	
	void Update ()
    {
		redVault = colourScript.redLight;
		greenVault = colourScript.greenLight;
		blueVault = colourScript.blueLight;

		redFloor = colourScript.red;
		greenFloor = colourScript.green;
		blueFloor = colourScript.blue;
	}

	void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
			if(floorNumber)
            {
				if(red)
                {
					textMesh.color = Color.red;
					textMesh.text = string.Format ("{0:N2}", redFloor);
				}

				if(green)
                {
					textMesh.color = Color.green;
					textMesh.text = string.Format ("{0:N2}", greenFloor);
				}

				if(blue)
                {
					textMesh.color = Color.blue;
					textMesh.text = string.Format ("{0:N2}", blueFloor);
				}

				textMesh.text = string.Format ("{0:N2} {1:N2} {2:N2}", redFloor, greenFloor, blueFloor);
			}
            else if (vaultNumber == true)
				textMesh.text = string.Format ("{0:N2} {1:N2} {2:N2}", redVault, greenVault, blueVault);
            else if(red == true)
				textMesh.text = string.Format ("{0:N2}", redFloor);
            else if(green == true)
				textMesh.text = string.Format ("{0:N2}", greenFloor);
            else if(blue == true)
				textMesh.text = string.Format ("{0:N2}", blueFloor);
		}
	}

	void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "Player")
			GetComponent<TextMesh> ().text = " ";
	}
}
