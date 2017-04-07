using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour {
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
	// Use this for initialization
	void Start () {
		buttons = GameObject.FindGameObjectsWithTag ("Button");
		floors = GameObject.FindGameObjectsWithTag ("Floor");
		vault = GameObject.FindGameObjectWithTag ("VaultMain");
		vaultCamera.GetComponent<Camera>().enabled = false;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
		blueLight = Random.Range (0.05f, 1f);
		remainderBlue = ((blueLight * 100) % 5);
		if (remainderBlue > 0) {
			blueLight = (((blueLight * 100)-remainderBlue)/100);
		}
		//blueLight =(( Mathf.RoundToInt(blueLight * 100))/100);
		redLight = Random.Range (0.05f, 1f);
		remainderRed = ((redLight * 100) % 5);
		if (remainderRed > 0) {
			redLight = (((redLight * 100) - remainderRed) / 100);
		}
		//redLight =(( Mathf.RoundToInt(redLight * 100))/100);
			greenLight = Random.Range (0.05f, 1f);
			remainderGreen = ((greenLight * 100) % 5);
			if (remainderGreen > 0) {
			//greenLight = (((greenLight * 100) - remainderGreen) / 100);
			greenLight = (((greenLight * 100) - remainderGreen) / 100);
		}
		//greenLight =(( Mathf.RoundToInt(greenLight * 100))/100);
				vault.GetComponent<Renderer> ().material.color = new Color (redLight, greenLight, blueLight, 0);
			}	
	// Update is called once per frame
	void FixedUpdate () {
		for (int i = 0; i < floors.Length; i ++) {
			floors [i].GetComponent<Renderer> ().material.color = new Color (red, green, blue, 0);
		}
		if (red > 1f) {
			red = 1f;
		}
		if (green > 1f) {
			green = 1f;
		}
		if (blue > 1f) {
			blue = 1f;
		}
			if ((red >= redLight - colourDiff) && (red <= redLight + colourDiff)) {
			if ((green >= greenLight - colourDiff) && (green <= greenLight + colourDiff)) {
				if ((blue >= blueLight - colourDiff) && (blue <= blueLight + colourDiff)) {
					if(camCount > 0){
						camCount -= 1;
						VaultOpen ();
						vaultOpen = true;
					}else{
						player.SetActive(true);
						mainCamera.GetComponent<Camera>().enabled = true;
						mainCamera.GetComponent<AudioListener> ().enabled = true;
						vaultCamera.GetComponent<AudioListener> ().enabled = false;
						vaultCamera.GetComponent<Camera>().enabled = false;
					}
				}	
			}
		}
	}
	public void Blue1(){
		blue += 0.05f;
	}
	public void Blue2(){
		blue += 0.1f;
	}
	public void Blue4(){
		blue += 0.2f;
	}
	public void BlueReset(){
		blue = 0f;
	}
	public void Red1(){
		red += 0.05f;
	}
	public void Red2(){
		red += 0.1f;
	}
	public void Red4(){
		red += 0.2f;
	}
	public void RedReset(){
		red = 0f;
	}
	public void Green1(){
		green += 0.05f;
	}
	public void Green2(){
		green += 0.1f;
	}
	public void Green4(){
		green += 0.2f;
	}
	public void GreenReset(){
		green = 0f;
	}
	public void Reset(){
		red = 0f;
		green = 0f;
		blue = 0f;
		hintCount = 4;
	}
	public void Hint(){

		if ((red > 0f) && (blue > 0f) && (green > 0)) {

			if (hintCount > -1) {
				hintCount -= 1;
				hintRand = Random.Range (1, 4);
				if (hintRand == 1) {
					print (((red - redLight) + ": " + hintCount + " hints remaining."));
				} else if (hintRand == 2) {
					print (((green - greenLight) + ": " + hintCount + " hints remaining."));
				} else {
					print (((blue - blueLight) + ": " + hintCount + " hints remaining."));
				}
			}else{
				print("No hints remaining, hit reset to try again!");
			}
		} else {
			print ("What are you trying to do, cheat?");
		}
}
	void VaultOpen(){
		//Debug.Log ("Vault Opening");
		GetComponent<BoxCollider> ().isTrigger = true;
		mainCamera.GetComponent<Camera>().enabled = false;
		mainCamera.GetComponent<AudioListener> ().enabled = false;
		vaultCamera.GetComponent<AudioListener> ().enabled = true;
		vaultCamera.GetComponent<Camera>().enabled = true;

		player.SetActive(false);
		for (int x = 0; x < buttons.Length; x++) {
			Destroy(buttons[x]);
		}
		//print ("A WINRAR IS YOU");

		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.03f, transform.position.z);
	}
}
