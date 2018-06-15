using UnityEngine;
using System.Collections;

public class ElevatorButton : MonoBehaviour
{
	public GameObject elevator;
	private Transform elevatorTransform;
	private GameObject player;
	private Transform playerTransform;
	public float speed;
	public bool groundFloor;
	public int travelCount;
	public bool travelling = false;

	void Start ()
    {
		elevatorTransform = elevator.GetComponent<Transform> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.GetComponent<Transform> ();
		speed = 0f;
	}
    
	void FixedUpdate ()
    {
		if (!travelling && playerTransform.position.y > 10f)
        {
			elevatorTransform.position = new Vector3 (elevatorTransform.position.x, 15f, elevatorTransform.position.z);
			groundFloor = false;
		}
        else if (!travelling && playerTransform.position.y < 10f)
        {
			elevatorTransform.position = new Vector3 (elevatorTransform.position.x, 0f, elevatorTransform.position.z);
			groundFloor = true;
		}

		elevatorTransform.position = new Vector3 (elevatorTransform.position.x, elevatorTransform.position.y + speed, elevatorTransform.position.z);

		if (travelling)
        {
			travelCount -= 1;
			playerTransform.position = new Vector3 (playerTransform.position.x,playerTransform.position.y + speed,playerTransform.position.z);

			if(travelCount < 0)
            {
				speed = 0f;
				travelling = false;
				travelCount = 300;
			}
		}
	}

	void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Player" && !travelling)
        {
			if(Input.GetKeyDown(KeyCode.E))
            {
			    travelling = true;
			    GetComponent<AudioSource>().Play();

                speed = groundFloor ? 0.05f : -0.05f;
                groundFloor = !groundFloor;
			}
	    }
    }
}
