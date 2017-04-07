using UnityEngine;
using System.Collections;

public class Wayfinder_Original_01 : MonoBehaviour {
	public GameObject lockGameObject;
	LockedHand lockScript;
	public GameObject playerChecker;
	public bool unlocked;

	public Transform[] wayPoints;
	public bool looped = true;
	public bool backwards = false;
	
	public float force = 200f;
	public int i = 0;
	private float posX;
	private float posZ;
	private float adj;
	private float hyp;
	private float opp;
	private float angle;

	//colourChange
	private int randNo;
	private ParticleSystem ptcl;

	void Start(){
		lockScript = lockGameObject.GetComponent<LockedHand> ();
		unlocked = lockScript.unlocked;

		ptcl = GetComponent<ParticleSystem> ();
		GetComponent<SphereCollider> ().isTrigger = true;
	}
	void Update () {
		unlocked = lockScript.unlocked;

		if (unlocked) {
			gameObject.tag = "Untagged";
			Destroy (playerChecker);
			int randNo = Random.Range (1, 3);
			if (randNo == 1) {
				ptcl.startColor = new Color (0, .2f, .05f, 1);
			} else {
				ptcl.startColor = new Color (0, 1, 0, 1);
			}
		} else {

			randNo = Random.Range (1, 3);
			if (randNo == 1) {
				ptcl.startColor = new Color (0, 0, 1, 1);
			} else {
				ptcl.startColor = new Color (0, 1, 1, 1);
			}
		}
	}

	void OnEnable(){
		//Debug.Log ("Enabled");
		GetComponent<SphereCollider> ().isTrigger = true;
		GetComponent<AudioSource> ().Stop ();
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (0, 0, 0);
		Angle ();
	}
	
	void Angle (){
		//checking the angle
		posX = transform.position.x;
		posZ = transform.position.z;
		adj = Mathf.Abs (posX - wayPoints[i].position.x);
		opp = Mathf.Abs (posZ - wayPoints[i].position.z);
		hyp = Mathf.Sqrt ((adj * adj) + (opp * opp));
		//print (hyp);
//		if (hyp < 5f) {
//			FindNextWayPoint();
//		}
		angle = Mathf.Acos (adj / hyp) * (Mathf.Rad2Deg);
		
		//checking which quadrant the angle is in
		if (posX < wayPoints[i].position.x) {
			if (posZ < wayPoints[i].position.z) {
				transform.Rotate(0, (90f - angle), 0);
			} else {
				transform.Rotate (0, (angle + 90f), 0);
			}
		} else {
			if (posZ < wayPoints[i].position.z) {
				transform.Rotate (0, angle - 90f, 0);
				
			} else {
				transform.Rotate (0, (-90f - angle), 0);
			}
		}
		//applying force
		GetComponent<Rigidbody>().AddForce (transform.forward.normalized * force);
	}
	
	void OnTriggerEnter(Collider target){
		
		//stopping and readjusting
		if (target.gameObject.tag == "Waypoint") {
			GetComponent<Rigidbody>().AddForce(transform.forward.normalized * -force);
			transform.rotation = Quaternion.Euler(0,0,0);
			
			FindNextWayPoint();

		}
	}

	void FindNextWayPoint(){
		if(looped == false){
			if((i >= wayPoints.Length - 1)||((backwards == true)&&(i > 0))){
				i -= 1;
				backwards = true;
			}else if((i <= 0)||((backwards == false)&&(i < wayPoints.Length - 1))){
				i += 1;
				backwards = false;
			}
		}else{
			if(backwards == false){
				if(i >= wayPoints.Length - 1){
					i = 0;
				}else{
					i += 1;
				}
			}else{
				if(i <= 0){
					i = wayPoints.Length - 1;
				}else{
					i -= 1;
				}
			}
		}
		Angle ();
	}
}
