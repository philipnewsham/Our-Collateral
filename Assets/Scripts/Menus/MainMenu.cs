using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	void Start ()
    {
		GetComponent<Camera> ().backgroundColor = new Color (Random.Range (0.01f, 0.99f), Random.Range (0.01f, 0.99f), Random.Range (0.01f, 0.99f), 1);
		Cursor.visible = true;
	}

	public void SelectLevel()
    {
		Application.LoadLevel (1);
	}

	public void Quit()
    {
		Application.Quit();
	}

	public void Controls()
    {
		Application.LoadLevel (2);
	}
}
