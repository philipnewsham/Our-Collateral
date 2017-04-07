using UnityEngine;
using System.Collections;

public class ShapeMaths : MonoBehaviour {
	public Sprite[] shapes;
	SpriteRenderer spriteR;
	int arrayCount = 0;
	// Use this for initialization
	void Start () {
		spriteR = GetComponent<SpriteRenderer> ();
		StartCoroutine ("ChangeShape");
	}
	void FixedUpdate(){
		spriteR.sprite = shapes[arrayCount];
	}
	
	// Update is called once per frame
	IEnumerator ChangeShape(){
		for (int i = 0; i > -1; i++) {
			
			//spriteR.sprite = shapes[arrayCount];
			arrayCount += 1;
			if(arrayCount == 2){
				arrayCount = 0;
			}
			yield return new WaitForSeconds (6);
		}
	}
}
