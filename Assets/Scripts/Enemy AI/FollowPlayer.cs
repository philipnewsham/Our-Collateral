using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	private GameObject player;
	private Transform playerTransform;
    private PlayerDeath playerDeath;
    private Rigidbody rigidbody;
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
    

	void Start ()
    {
		ptcl = GetComponent<ParticleSystem> ();
		player = GameObject.FindGameObjectWithTag ("Player");
        playerTransform = player.GetComponent<Transform>();
        playerDeath = player.GetComponent<PlayerDeath>();
        rigidbody = GetComponent<Rigidbody>();
    }

	void Update ()
    {
		if (playerDeath.dead)
			GetComponent<AudioSource> ().Stop ();

		randNo = Random.Range (1,3);
        ptcl.startColor = new Color(1, (randNo == 1 ? 0 : 1), 0, 1);
	}	

	void FixedUpdate()
    {
		CheckPlayer ();
	}

	void OnEnable()
    {
		GetComponent<AudioSource> ().Play ();
		Debug.Log ("Enabled");
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (0, 0, 0);
	}
	
	void CheckPlayer()
    {
		rigidbody.velocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (0, 0, 0);

		posX = transform.position.x;
		posZ = transform.position.z;
		adj = Mathf.Abs (posX - playerTransform.position.x);
		opp = Mathf.Abs (posZ - playerTransform.position.z);
		hyp = Mathf.Sqrt ((adj * adj) + (opp * opp));
		
		angle = Mathf.Acos (adj / hyp) * (Mathf.Rad2Deg);

        //checking which quadrant the angle is in
        float yRot = 0.0f;
		if (posX < playerTransform.position.x)
            yRot = posZ < playerTransform.position.z ? 90.0f - angle : angle + 90.0f;
        else
            yRot = posZ < playerTransform.position.z ? angle - 90.0f : -90.0f - angle;
        transform.Rotate(0.0f, yRot, 0.0f);
		//applying force
		rigidbody.AddForce (transform.forward.normalized * force);
	}
}