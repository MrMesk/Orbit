using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour 
{
	public float lifeTime;
	float timer;
	// Use this for initialization
	void Start () 
	{
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if ( timer >= lifeTime )
		{
			Destroy (this.gameObject);
		}
	}
}
