using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
	int randomNumber1;
	int randomNumber2;
	public float time = 0;
	public Color[] colours;
	int factor;
	int count;

	void Start ()
    {
		Cursor.visible = false;
		randomNumber1 = Random.Range (0, colours.Length + 1);
		randomNumber2 = Random.Range (0, colours.Length + 1);
	}
	
	void FixedUpdate ()
    {
		time += Time.deltaTime;
		if (time > 1)
        {
			time = 0;
			randomNumber1 = randomNumber2;
			randomNumber2 = Random.Range (0, colours.Length + 1);
		}

		GetComponent<Renderer> ().material.color = Color.Lerp (colours [randomNumber1], colours [randomNumber2], time);
	}
}
