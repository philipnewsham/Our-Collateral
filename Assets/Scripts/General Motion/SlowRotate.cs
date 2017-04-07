using UnityEngine;
using System.Collections;

public class SlowRotate : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3 (0, 1, 0) * speed);
	}
}
