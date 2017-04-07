using UnityEngine;
using System.Collections;

public class PlayerCheckerScript : MonoBehaviour {
	public bool alarmed;
	public bool inAction;
	public GameObject alien;
	private Transform alienMove;

	private Wayfinder_Original_01 wayfinderScript;
	private FollowPlayer followPlayerScript;

	void Start(){
		alarmed = false;
		inAction = false;
		wayfinderScript = alien.GetComponent<Wayfinder_Original_01> ();
		followPlayerScript = alien.GetComponent<FollowPlayer> ();
	}
	void Update(){
		alienMove = alien.GetComponent<Transform> ();
		transform.position = new Vector3 (alienMove.position.x, alienMove.position.y, alienMove.position.z);
	}
	void OnTriggerEnter (Collider other){
	
		if (other.gameObject.tag == "Player") {
			wayfinderScript.enabled = false;
			followPlayerScript.enabled = true;
//			alarmed = true;
//			inAction = false;
//			alien.GetComponent<Pathfinder>().Checkem();
		}
	}
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			followPlayerScript.enabled = false;
			wayfinderScript.enabled = true;
//			Debug.Log ("Left");
//			alarmed = false;
//			inAction = false;
//			alien.GetComponent<Pathfinder>().Checkem();
		}
	}

}
