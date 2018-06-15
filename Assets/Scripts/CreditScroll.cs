using UnityEngine;
using System.Collections;

public class CreditScroll : MonoBehaviour
{
	float count;
	RectTransform creditTransform;
	public float speed;
	public bool stop;
	public bool enter;

	void Start ()
    {
		creditTransform = GetComponent<RectTransform> ();
		count = creditTransform.position.y;
	}
	
	void FixedUpdate ()
    {
		count +=  (Screen.height/10) * Time.deltaTime;
		creditTransform.position = new Vector2 (creditTransform.position.x, count);
		if (stop)
        {
			if(!enter)
            {
				if(creditTransform.position.y > Screen.height/4)
					creditTransform.position = new Vector2 (creditTransform.position.x, Screen.height/4);
		    }
            else
            {
				if(creditTransform.position.y > (Screen.height/4 - (Screen.height/4)))
					creditTransform.position = new Vector2 (creditTransform.position.x, (Screen.height/4 - (Screen.height/4)));
	        }
        }

		if (Input.GetKeyDown (KeyCode.Return))
			Application.LoadLevel(0);
    }
}