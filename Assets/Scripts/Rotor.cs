using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour 
{
	public float rotateSpeed;
    public float turnSpeed;
	public float accel;
	public float maxSpeed;
	public float minSpeed;
	float actualSpeed;

	// Use this for initialization
	void Start () 
	{
		actualSpeed = rotateSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Rotate ( new Vector3 ( actualSpeed * Time.deltaTime,0,0));

		if(Input.GetAxis("Horizontal") != 0f)
		{
			transform.Rotate ( new Vector3 ( 0,0,turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal") * -1f ));
		}

	}
}
