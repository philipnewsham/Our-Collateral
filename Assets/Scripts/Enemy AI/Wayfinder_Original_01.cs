using UnityEngine;
using System.Collections;

public class Wayfinder_Original_01 : MonoBehaviour
{
	public GameObject lockGameObject;
	LockedHand lockScript;
	public GameObject playerChecker;
    private Rigidbody rigidbody;
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

	void Awake()
    {
		lockScript = lockGameObject.GetComponent<LockedHand> ();
		unlocked = lockScript.unlocked;
        rigidbody = GetComponent<Rigidbody>();
		ptcl = GetComponent<ParticleSystem> ();
		GetComponent<SphereCollider> ().isTrigger = true;
	}

	void Update ()
    {
		unlocked = lockScript.unlocked;
        int randNo = Random.Range(0, 2);
		if (unlocked)
        {
			gameObject.tag = "Untagged";
			Destroy (playerChecker);
            ptcl.startColor = randNo == 0 ? new Color(0, 0.2f, 0.05f, 1) : new Color(0, 1, 0, 1);
		}
        else
        {
            ptcl.startColor = new Color(0, randNo, 1, 1);
		}
	}

	void OnEnable()
    {
		GetComponent<SphereCollider>().isTrigger = true;
		GetComponent<AudioSource>().Stop ();
		rigidbody.velocity = Vector3.zero;
		transform.rotation = Quaternion.Euler(0, 0, 0);
		Angle();
	}
	
	void Angle()
    {
		posX = transform.position.x;
		posZ = transform.position.z;
		adj = Mathf.Abs (posX - wayPoints[i].position.x);
		opp = Mathf.Abs (posZ - wayPoints[i].position.z);
		hyp = Mathf.Sqrt ((adj * adj) + (opp * opp));
		angle = Mathf.Acos (adj / hyp) * (Mathf.Rad2Deg);

        //checking which quadrant the angle is in
        float yRot = 0.0f;

		if (posX < wayPoints[i].position.x)
            yRot = posZ < wayPoints[i].position.z ? 90.0f - angle : angle + 90.0f;
        else
            yRot = posZ < wayPoints[i].position.z ? angle - 90.0f : -90.0f - angle;

        transform.Rotate(0.0f, yRot, 0.0f);
		//applying force
		rigidbody.AddForce (transform.forward.normalized * force);
	}
	
	void OnTriggerEnter(Collider target)
    {
		//stopping and readjusting
		if (target.gameObject.tag == "Waypoint")
        {
			rigidbody.AddForce(transform.forward.normalized * -force);
			transform.rotation = Quaternion.Euler(0,0,0);
			FindNextWayPoint();
		}
	}

	void FindNextWayPoint()
    {
        if (looped)
        {
            if (backwards)
                i = (i - 1) < 0 ? wayPoints.Length - 1 : i - 1;
            else
                i = (i + 1) % wayPoints.Length;
        }
		else
        {
			if((i >= wayPoints.Length - 1)||((backwards == true) && (i > 0)))
            {
				i -= 1;
				backwards = true;
			}
            else if((i <= 0)||((!backwards) && (i < wayPoints.Length - 1)))
            {
				i += 1;
				backwards = false;
			}
		}
		Angle ();
	}
}