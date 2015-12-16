using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour 
{
	public string crystalColor;
	public float lifeTime;
	public int maxIterations;
	int iterations;

	float timer;

	// Use this for initialization
	void Start () 
	{
		timer = 0f;
		iterations = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if(timer >= lifeTime)
		{
			GetComponent<ParticleSystem>().startSpeed = GetComponent<ParticleSystem>().startSpeed * 2;
			GetComponent<ParticleSystem>().maxParticles = GetComponent<ParticleSystem>().maxParticles * 2;
			GetComponent<ParticleSystem>().emissionRate = GetComponent<ParticleSystem>().emissionRate * 2;
			GetComponent<ParticleSystem>().startLifetime = GetComponent<ParticleSystem>().startLifetime /2;
			timer = 0f;
			iterations ++;
		}
		if(iterations >= maxIterations)
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
			Debug.Log("Something entered Enter");
			Destroy (this.gameObject);
	}


}
