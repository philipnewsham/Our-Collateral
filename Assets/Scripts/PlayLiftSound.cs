using UnityEngine;
using System.Collections;

public class PlayLiftSound : MonoBehaviour {
	public GameObject liftButton;
	ElevatorButton liftScript;
	bool travelling;

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		liftScript = liftButton.GetComponent<ElevatorButton> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		travelling = liftScript.travelling;

		if (travelling) {
			if(!audioSource.isPlaying){
			audioSource.Play ();
			}
		} else {
			audioSource.Stop ();
		}
	}
}