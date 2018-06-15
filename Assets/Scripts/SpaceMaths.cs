using UnityEngine;
using System.Collections;

public class SpaceMaths : MonoBehaviour
{
	int randomNo1;
	int randomNo2;
	int equation;
	public float count;
	TextMesh textMesh;

	void Start ()
    {
		textMesh = GetComponent<TextMesh> ();
		StartCoroutine ("Maths");
	}

	void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Player")
			textMesh.text = (randomNo1 + " + " + randomNo2 + " = " + equation);
	}

	void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "Player")
			textMesh.text = (" ");
	}

	IEnumerator Maths()
    {
		for (int i = 0; i > -1; i++)
        {
			randomNo1 = Random.Range (0, 10);
			randomNo2 = Random.Range (0, 10 - randomNo1);
			equation = randomNo1 + randomNo2;
			yield return new WaitForSeconds (6);
		}
	}
}