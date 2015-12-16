using UnityEngine;
using System.Collections;

public class NewRotor : MonoBehaviour 
{
	public float rotateSpeed;
	bool isLocked;
	float actualSpeed;
	float dirRotate;
	
	// Use this for initialization
	void Start () 
	{
		actualSpeed = rotateSpeed;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (isLocked)
		{
			transform.Rotate( new Vector3 ( actualSpeed * Time.deltaTime * dirRotate,0,0));
		}

		if(Input.GetAxis("Horizontal") != 0f)
		{
			transform.Rotate ( new Vector3 ( 0,0,actualSpeed * Time.deltaTime * Input.GetAxis("Horizontal") * -1f ));
		}

		if(Input.GetAxis("Vertical") != 0f && !isLocked)
		{
			dirRotate = Input.GetAxis ("Vertical");
			transform.Rotate ( new Vector3 ( actualSpeed * Time.deltaTime * Input.GetAxis("Vertical"),0,0));
		}

		if ( Input.GetButtonDown("Lock"))
		{
			if (isLocked) isLocked = false;
			else isLocked = true;
			
		}
	}
}
