using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public Vector3 mouse;
	private Camera cam;
//	void Update() {
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast(ray, out hit, 100)) {
//			Debug.DrawLine(ray.origin, hit.point);
//		}
//	}
	void Awake(){
		cam = Camera.main;
	}

	void Update(){
		mouse = Input.mousePosition;
	}

}
