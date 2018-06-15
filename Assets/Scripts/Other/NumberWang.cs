using UnityEngine;
using System.Collections;

public class NumberWang : MonoBehaviour
{
	public int yourNumber;
	private int noMin;
	private int noMax;
	private int noNew;
	private int turns;

	void Start ()
    {
		turns = 0;
		noMin = 0;
		noMax = 1000;
	}

	void Update ()
    {
		if (Input.GetKeyDown (KeyCode.Space))
			StartCoroutine (NumberWangers());
	}

	IEnumerator NumberWangers()
    {
		while(noNew != yourNumber)
        {
			turns += 1;
			noNew = Random.Range(noMin, noMax);

			if (noNew > yourNumber)
				noMax = noNew;
            else if (noNew < yourNumber)
				noMin = noNew;
            else
		        print("Found in " + turns + " turns");

			print(noMin + ", " + noMax);
			yield return new WaitForSeconds (1);
		}
	}
}
