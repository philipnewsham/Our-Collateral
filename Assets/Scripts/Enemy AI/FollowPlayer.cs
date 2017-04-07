using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	private GameObject player;
	private Transform playerTransform;
	private float force = 200f;
	private float posX;
	private float posZ;
	private float adj;
	private float hyp;
	private float opp;
	private float angle;

	//colourChange
	private int randNo;
	private ParticleSystem ptcl;

	private bool playerDead;

	void Start () {
		//GetComponent<SphereCollider> ().isTrigger = false;
		ptcl = GetComponent<ParticleSystem> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update (){
		playerTransform = player.GetComponent<Transform> ();
		playerDead = player.GetComponent<PlayerDeath> ().dead;
		if (playerDead == true) {
			GetComponent<AudioSource> ().Stop ();
		}
			//CheckPlayer ();
		randNo = Random.Range (1,3);
		if(randNo == 1){
			ptcl.startColor = new Color (1, 0, 0, 1);
		}else{
			ptcl.startColor = new Color (1, 1, 0, 1);
		}
	}	
	void FixedUpdate(){
		CheckPlayer ();
	}

	void OnEnable(){
		//GetComponent<SphereCollider> ().isTrigger = false;
		GetComponent<AudioSource> ().Play ();
		Debug.Log ("Enabled");
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (0, 0, 0);
		//InvokeRepeating ("CheckPlayer", 0,Time.deltaTime);
	}

	void OnDisable(){

	}
	
	void CheckPlayer(){
		//for (int i = 0; i < 1000000; i++) {

		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (0, 0, 0);

			posX = transform.position.x;
			posZ = transform.position.z;
			adj = Mathf.Abs (posX - playerTransform.position.x);
			opp = Mathf.Abs (posZ - playerTransform.position.z);
			hyp = Mathf.Sqrt ((adj * adj) + (opp * opp));
		
			angle = Mathf.Acos (adj / hyp) * (Mathf.Rad2Deg);
		
			//checking which quadrant the angle is in
			if (posX < playerTransform.position.x) {
				if (posZ < playerTransform.position.z) {
					transform.Rotate (0, (90f - angle), 0);
				} else {
					transform.Rotate (0, (angle + 90f), 0);
				}
			} else {
				if (posZ < playerTransform.position.z) {
					transform.Rotate (0, angle - 90f, 0);
				} else {
					transform.Rotate (0, (-90f - angle), 0);
				}
			}
			//applying force
			GetComponent<Rigidbody> ().AddForce (transform.forward.normalized * force);
	}
}