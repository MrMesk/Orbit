using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SpawnTree : MonoBehaviour 
{

	public GameObject spawner;

	public float reloadTime;
	float timer;
	bool canShoot;
	public AudioClip shotSound;
	AudioSource audioPlayer;

	// Use this for initialization
	void Start () 
	{
		canShoot = true;
		Cursor.visible = false;
		audioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (Input.GetMouseButton(0) && canShoot)
		{
			Instantiate(spawner,transform.position, transform.rotation);
			canShoot = false;
			audioPlayer.PlayOneShot(shotSound);
		}
		if(canShoot == false)
		{
			
			if(timer >= reloadTime)
			{
				timer = 0f;
				canShoot = true;
			}
			else timer += Time.deltaTime;
		}
	}
}
