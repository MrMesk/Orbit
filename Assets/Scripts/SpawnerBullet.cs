using UnityEngine;
using System.Collections;

public class SpawnerBullet : MonoBehaviour 
{
	public GameObject normalCrystal;

	public float speed;
	
	Ray ray;
	public float colliderSize;
	bool toDestroy;
	public float destroyTime;
	float destroyTimer;

	GameObject toSpawn;

	// Use this for initialization
	void Start () 
	{
		toDestroy = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		RaycastHit hit;
		if(Physics.Raycast (transform.position, transform.forward, out hit, colliderSize) && !toDestroy)
		{

			if ( hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "Crystal")
			{
				
				GameObject bullet = Instantiate(normalCrystal, transform.position, transform.rotation) as GameObject;
				bullet.GetComponent<Grow>().StartCoroutine(bullet.GetComponent<Grow>().AddCrystal());		
				toDestroy = true;
			}
		}

		if (!toDestroy) 
		{
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		else
		{
			destroyTimer += Time.deltaTime;
			if(destroyTimer >= destroyTime)
			{
				Destroy (this.gameObject);
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Light")
		{
			toDestroy = true;
		}
	}
	
}
