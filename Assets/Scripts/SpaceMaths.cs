using UnityEngine;
using System.Collections;

public class SpaceMaths : MonoBehaviour {
// 	int triangle;
// 	int diamond;
// 	int hexagon;
	int randomNo1;
	int randomNo2;
	int equation;
	public float count;
	TextMesh textMesh;
	// Use this for initialization
	void Start () {
//		triangle = 5;
//		diamond = 10;
//		hexagon = 20;
		textMesh = GetComponent<TextMesh> ();
		StartCoroutine ("Maths");

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			textMesh.text = (randomNo1 + " + " + randomNo2 + " = " + equation);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			textMesh.text = (" ");
		}
	}

	IEnumerator Maths(){
		for (int i = 0; i > -1; i++) {
			randomNo1 = Random.Range (0, 10);
			randomNo2 = Random.Range (0, 10-randomNo1);
			equation = randomNo1 + randomNo2;



			yield return new WaitForSeconds (6);
		}
	}
}

