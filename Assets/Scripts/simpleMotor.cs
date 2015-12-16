using UnityEngine;
using System.Collections;

public class simpleMotor : MonoBehaviour 
{
	Rigidbody rigid;
	Vector3 dir;
	public float speed;
	public float rotateSpeed;
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		dir = Vector3.zero;

		if(Input.GetAxis("Horizontal") !=0)
		{
			//dir += transform.right * Input.GetAxis("Horizontal");
			transform.Rotate (new Vector3 (0,0,rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
		}
		if(Input.GetAxis("Vertical") !=0)
		{
			dir += transform.forward * Input.GetAxis("Vertical");
		}
		rigid.velocity = dir * speed * Time.deltaTime;
	}
}
