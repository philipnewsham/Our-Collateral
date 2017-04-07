using UnityEngine;
using System.Collections;

public class SkyboxSpin : MonoBehaviour {
	private float dirX;
	private float dirY;
	private float dirZ;
	public float speed;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("GetRotation", 0, 10);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3 (dirX, dirY, dirZ) * speed);
	}
	void GetRotation(){
		dirX = Random.Range (-1f, 1f);
		dirY = Random.Range (-1f, 1f);
		dirZ = Random.Range (-1f, 1f);
	}
}
