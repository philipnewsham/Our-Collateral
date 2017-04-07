using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountingDownScript : MonoBehaviour {
	float count;
	public float timer;
	public GameObject spaceship;
	RectTransform shipTransform;
	float percentage;

	public bool outOfTime = false;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		count = 0;
		shipTransform = spaceship.GetComponent<RectTransform> ();
		shipTransform.position = new Vector2 ((Screen.width / 100) * 10, shipTransform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		count += Time.deltaTime;
		percentage = (count/timer)*100;
		if (percentage < 10) {
			shipTransform.position = new Vector2 ((Screen.width / 100) * 10, shipTransform.position.y);
		} else if (percentage > 90) {
			shipTransform.position = new Vector2 (Screen.width - ((Screen.width / 100) * 10), shipTransform.position.y);
		} else {
			shipTransform.position = new Vector2 (((Screen.width / 100) * percentage), shipTransform.position.y);
		}
		if (count > timer) {
			outOfTime = true;
			shipTransform.position = new Vector2 (Screen.width - ((Screen.width / 100) * 10), shipTransform.position.y);
		}
	}
}
