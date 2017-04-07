using UnityEngine;
using System.Collections;

public class Counting : MonoBehaviour {
	int x;
	int y;
	// Use this for initialization
	void Start () {
		for (x = 0; x < x + 1; x++) {
			y = x + 1;
			x = y + 1;
			print (x);
		}
	}
}
