using UnityEngine;
using System.Collections;

public class Strating : MonoBehaviour 
{
	public float speed;
	public GameObject mainCamera;
	Vector3 dirToMid;
	float distanceToMid;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKey (KeyCode.A))
		{
			distanceToMid = Vector3.Distance(mainCamera.transform.position,Vector3.zero);
			Debug.Log (distanceToMid);
			if(distanceToMid < 115 )
			{
				transform.position += transform.up * speed * Time.deltaTime;
			}
		}
		else if(Input.GetKey (KeyCode.E))
		{
			distanceToMid = Vector3.Distance(mainCamera.transform.position,Vector3.zero);
			Debug.Log (distanceToMid);
			if(distanceToMid > 60 )
			{
				transform.position -= transform.up * speed * Time.deltaTime;
			}
		}
	}
}
