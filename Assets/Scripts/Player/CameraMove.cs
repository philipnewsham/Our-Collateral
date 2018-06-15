using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	public Vector3 mouse;
	private Camera cam;

	void Awake()
    {
		cam = Camera.main;
	}

	void Update()
    {
		mouse = Input.mousePosition;
	}
}