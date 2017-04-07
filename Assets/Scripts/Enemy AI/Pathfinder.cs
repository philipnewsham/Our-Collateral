using UnityEngine;
using System.Collections;

public class Pathfinder : MonoBehaviour {
	//gets position of waypoints and player
	public Transform[] wayPoints;
	public Transform player;
	//checks to see what type of patrol the alien has
	public bool looped = true;
	public bool backwards = false;
	//force the alien moves, what waypoint it's on and what its position is
	private float force = 300f;
	private int i = 0;
	private float posX;
	private float posZ;
	//use these to find the angle needed to turn to the next waypoint
	private float adj;
	private float hyp;
	private float opp;
	private float angle;
	//checks to see if it is in a current mode or changing
	private bool inAction;
	//grabs references from playerchecker
	public GameObject playerChecker;
	private PlayerCheckerScript plyrCheckScript;
	private bool alarmed;
	//colour system
	private int randNo;
	private ParticleSystem ptcl;

	private bool started = false;
	//Getting starting points and components
	void Start(){
		ptcl = GetComponent<ParticleSystem> ();
		plyrCheckScript = playerChecker.GetComponent<PlayerCheckerScript> ();

		alarmed = plyrCheckScript.alarmed;
		inAction = plyrCheckScript.inAction;
	}
	//checks to see which mode it's in (Alarmed or not)
	void Update (){
		if (started == false) {
			if (inAction == false) {
				started = true;
				inAction = true;
				if (alarmed == false) {
					NextWayPoint ();
				} else {
					CheckPlayer ();
				}
			}
		}else {
				if (inAction == false) {
				//Debug.Log("JustCheckin");
					inAction = true;
					if (alarmed == false) {
						NextWayPoint ();
					} else {
						CheckPlayer ();
					}
				}
			}

		//Changes colour based on alarm status
		randNo = Random.Range (1,3);
		if (alarmed == true) {
			if(randNo == 1){
				ptcl.startColor = new Color (1, 0, 0, 1);
			}else{
				ptcl.startColor = new Color (1, 1, 0, 1);
			}
		} else {
			if(randNo == 1){
				ptcl.startColor = new Color (0, 0, 1, 1);
			}else{
				ptcl.startColor = new Color (0, 1, 1, 1);
			}
		}

	}
	//Finds next point, and moves towards it
	void NextWayPoint (){
		//Debug.Log ("Back Again!");
		//checking the angle
			posX = transform.position.x;
			posZ = transform.position.z;
			adj = Mathf.Abs (posX - wayPoints[i].position.x);
			opp = Mathf.Abs (posZ - wayPoints[i].position.z);
			hyp = Mathf.Sqrt ((adj * adj) + (opp * opp));

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
				//Debug.Log("Check em");
				} else {
				transform.Rotate (0, (-90f - angle), 0);
				}
			}
		//applying force
				GetComponent<Rigidbody>().AddForce (transform.forward.normalized * force);
		//Debug.Log ("We Applied now?");
			}
	//When it collides with a waypoint, resets motion and rotation, then chooses the next point
	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag == "Waypoint") {
			if (alarmed == false) {
				//Debug.Log ("Made it through customs");
				GetComponent<Rigidbody>().AddForce(transform.forward.normalized * -force);
				transform.rotation = Quaternion.Euler(0,0,0);
				//checking if it's looped or patrol, and then which direction it's going.
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
				NextWayPoint ();
			}
		}
	}
	//Checking Player position and moving towards that point
	void CheckPlayer(){
		if (alarmed == true) {
			posX = transform.position.x;
			posZ = transform.position.z;
			adj = Mathf.Abs (posX - player.position.x);
			opp = Mathf.Abs (posZ - player.position.z);
			hyp = Mathf.Sqrt ((adj * adj) + (opp * opp));
		
			angle = Mathf.Acos (adj / hyp) * (Mathf.Rad2Deg);
		
			//checking which quadrant the angle is in
			if (posX < player.position.x) {
				if (posZ < player.position.z) {
					transform.Rotate (0, (90f - angle), 0);
				} else {
					transform.Rotate (0, (angle + 90f), 0);
				}
			} else {
				if (posZ < player.position.z) {
					transform.Rotate (0, angle - 90f, 0);
				} else {
					transform.Rotate (0, (-90f - angle), 0);
				}
			}
			//applying force
			GetComponent<Rigidbody> ().AddForce (transform.forward.normalized * force);
			Invoke ("StopPlayer", 0.1f);
		} else {

			GetComponent<Rigidbody> ().AddForce (transform.forward.normalized * -force);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			inAction = false;
		}
	}
	//Stops motion, resets the angle, and tells it to go back to CheckPlayer
	void StopPlayer(){
		GetComponent<Rigidbody> ().AddForce (transform.forward.normalized * -force);
		transform.rotation = Quaternion.Euler (0, 0, 0);
		CheckPlayer ();
	}
	//checks current status of alarmed and inAction from the playerCheck component
	public void Checkem (){
		alarmed = plyrCheckScript.alarmed;
		inAction = plyrCheckScript.inAction;
		if (inAction == false) {
			GetComponent<Rigidbody> ().AddForce (transform.forward.normalized * -force);
			transform.rotation = Quaternion.Euler (0, 0, 0);
			if (alarmed == false) {
				NextWayPoint ();
			} else {
				CheckPlayer ();
			}
		}
	}
}