using UnityEngine;
using System.Collections;

public class Counting : MonoBehaviour
{
	int x;
	int y;

	void Start ()
    {
		for (x = 0; x < x + 1; x++)
        {
			y = x + 1;
			x = y + 1;
			print (x);
		}
	}
}
