using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    //colours
    private ParticleSystem particles;
    public Color[] colours;

    public enum EnemyState
    {
        PATROL,
        ALERT,
        NEUTRAL
    }

    private EnemyState currentState;
    private ParticleSystem.MainModule mainModule;

    //neutral
    public GameObject lockGameObject;
    private LockedHand lockScript;
    public GameObject playerChecker;

    //tracking
    private float force = 200.0f;
    private Transform playerTransform;
    public bool looped;
    public bool backwards;
    public Transform wayPointParent;
    private List<Transform> wayPoints = new List<Transform>();
    private int wayPointNo = 0;
    private AudioSource audioSource;

    void Awake()
    {
        //tracking
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        thisRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //colour
        currentState = EnemyState.PATROL;
        particles = GetComponent<ParticleSystem>();
        mainModule = particles.main;
        foreach (Transform child in wayPointParent)
            wayPoints.Add(child);
        FindNextWayPoint();

        //neutral
        lockScript = lockGameObject.GetComponent<LockedHand>();
        StartCoroutine(WaitForUnlock());
    }

    public void SetEnemyState(EnemyState state)
    {
        currentState = state;
        if (state != EnemyState.ALERT)
        {
            FindNextWayPoint();
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        int rng = Random.Range(0, 2);
        mainModule.startColor = colours[((int)currentState * 2) + rng];
    }

    void FixedUpdate()
    {
        if (currentState == EnemyState.ALERT)
            UpdateTracking(playerTransform);
    }
    
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Waypoint":
                if (currentState != EnemyState.ALERT)
                {
                    Reset();
                    FindNextWayPoint();
                }
                break;
        }
    }

    void FindNextWayPoint()
    {
        if (looped)
        {
            if (backwards)
                wayPointNo = (wayPointNo - 1) < 0 ? wayPoints.Count - 1 : wayPointNo - 1;
            else
                wayPointNo = (wayPointNo + 1) % wayPoints.Count;
        }
        else
        {
            if ((wayPointNo >= wayPoints.Count - 1) || ((backwards) && (wayPointNo > 0)))
            {
                wayPointNo -= 1;
                backwards = true;
            }
            else if ((wayPointNo <= 0) || ((!backwards) && (wayPointNo < wayPoints.Count - 1)))
            {
                wayPointNo += 1;
                backwards = false;
            }
        }

        UpdateTracking(wayPoints[wayPointNo]);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetEnemyState(EnemyState.PATROL);
        }
    }

    void UpdateTracking(Transform target)
    {
        Reset();
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
        thisRigidbody.AddForce(transform.forward.normalized * force);
    }

    void Reset()
    {
        thisRigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    IEnumerator WaitForUnlock()
    {
        yield return new WaitUntil(() => lockScript.unlocked);
        gameObject.tag = "Untagged";
        Destroy(playerChecker);
        SetEnemyState(EnemyState.NEUTRAL);
    }
}