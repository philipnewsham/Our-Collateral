using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {
	public float targetHeight;
	private Rigidbody rb;

	private float plusMinus = 1f;
	public float forceUp;
	public float forceDown;
	private float gravity = 9.81f;
	private int onezero;
	private bool above = false;

	public float force;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	

		//force = gravity + (targetHeight - transform.position.y);

		if (transform.position.y < targetHeight) {
			force = gravity + (targetHeight - transform.position.y);
			rb.AddForce (new Vector3 (0, force, 0));
		} else if (transform.position.y > targetHeight) {
			force = gravity;
		}

//		if (transform.position.y < targetHeight) {
//			onezero = 0;
//			forceUp = gravity + plusMinus;
//			if(above == false){
//				above = true;
//				if(forceUp > gravity){
//				plusMinus -= 0.02f;
//			}
//			}
//		}
//		if (transform.position.y > targetHeight) {
//			onezero = 1;
//			forceDown = gravity - plusMinus;
//			if(above == true){
//				above = false;
//				if(forceDown < gravity){
//					plusMinus -= 0.02f;
//				}
//			}
//		}
		if (targetHeight == transform.position.y) {
			rb.AddForce (new Vector3 (0, 9.81f, 0));
		} else {
			rb.AddForce (new Vector3 (0,Mathf.Lerp (forceUp,forceDown, onezero), 0));
			//rb.AddForce (new Vector3 (0f,Mathf.Lerp(10, 5, force),0f));
		}

	}
}
