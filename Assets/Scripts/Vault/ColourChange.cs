using UnityEngine;
using System.Collections;

public class ColourChange : MonoBehaviour {
	private Light lt;

	public float red;
	public float blue;
	public float green;

	public GameObject[] buttons;
	public Button buttonScript;

	private int i;
	// Use this for initialization
	void Start () {
		lt = GetComponent<Light> ();

		buttons = GameObject.FindGameObjectsWithTag ("Button");
		//for (i = 0; i < buttons.Length; i ++) {
		//	buttonScript [1] = buttons[1].GetComponents<Button>();
		//}
			CheckColour ();
	}
	
	// Update is called once per frame
	void Update () {
//	foreach (GameObject button in buttons) {
//		if (i == 0) {
//			CheckColour ();
//		} else if (i >= buttons.Length) {
//			i = 0;
//		}
}

	void CheckColour(){
		for (i = 0; i < buttons.Length; i ++) {

			//red = buttonScript[i].red;
			if (red > 1) {
				red = 1;
			}

			//blue = buttonScript[i].blue;
			if (blue > 1) {
				blue = 1;
			}

			//green = buttonScript[i].green;
			if (green > 1) {
				green = 1;
			}

			lt.color = new Color (red, green, blue, 1);
		}
	}

}