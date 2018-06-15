using UnityEngine;
using System.Collections;

public class FieldDrop : MonoBehaviour
{
	public float count;
	bool isPlaying;
	
	void Update ()
    {
		count -= 1 * Time.deltaTime;
	}

	void FixedUpdate()
    {
		if (count < 0)
        {
			Destroy (gameObject, 2);

			if(!isPlaying)
            {
				isPlaying = true;
				GetComponent<AudioSource>().Play();
			}

			transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
		}
	}
}
