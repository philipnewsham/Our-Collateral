using UnityEngine;
using System.Collections;

public class PlayerCheckerScript : MonoBehaviour
{
	public bool alarmed;
	public bool inAction;
	public GameObject alien;
	private Transform alienMove;
    private AlienController alienController;
    public float count;

	void Start()
    {
		alarmed = false;
		inAction = false;
		alienController = alien.GetComponent<AlienController>();
        alienMove = alien.GetComponent<Transform>();
        Invoke("EnableCollider", count);
    }

    void EnableCollider()
    {
        GetComponent<SphereCollider>().enabled = true;
    }

    void Update()
    {
		transform.position = new Vector3 (alienMove.position.x, alienMove.position.y, alienMove.position.z);
	}

	void OnTriggerEnter (Collider other)
    {
		if (other.gameObject.tag == "Player")
            alienController.SetEnemyState(AlienController.EnemyState.ALERT);
	}

	void OnTriggerExit (Collider other)
    {
		if (other.gameObject.tag == "Player")
            alienController.SetEnemyState(AlienController.EnemyState.PATROL);
	}
}