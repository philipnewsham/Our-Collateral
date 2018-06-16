using UnityEngine;
using System.Collections;

public class FieldDrop : MonoBehaviour
{
	public float count;
	bool isPlaying;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(SlideDown());
    }

    IEnumerator SlideDown()
    {
        yield return new WaitForSeconds(10.0f);
        audioSource.Play();
        float lerpTime = 0.0f;
        while(lerpTime <= 1.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            lerpTime += lerpTime * Time.deltaTime;
            yield return null;
        }
        audioSource.Stop();
    }
}
