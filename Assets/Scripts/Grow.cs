using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour 
{
	public float desiredScale;
	public float minMax;
	public float growSpeed;
	public float rotateMax;

    public float rotateSpeed;

    public float orbitClosingSpeed;

    public string coreName = "CrystalCore";

	public LayerMask lightLayer;

	float randScale;
	Vector3 actualScale;

    Vector3 dirToCore;
    GameObject mid;

	Vector3 randomRotateX;
	Vector3 randomRotateY;
	Vector3 randomRotateZ;

	bool dying = false;

	float rotateSpeedX;
	float rotateSpeedY;
	float rotateSpeedZ;

	GameObject possibleLight;
    public bool isOrbiting = false;

	// Use this for initialization
	void Awake () 
	{
		dying = false;
		rotateSpeedX = Random.Range(0f, rotateSpeed);
		rotateSpeedY = Random.Range(0f, rotateSpeed);
		rotateSpeedZ = Random.Range(0f, rotateSpeed);

		randomRotateX = transform.forward * Random.Range(0, 2);
		randomRotateY = transform.up * Random.Range(0, 2);
		randomRotateZ = transform.right * Random.Range(0, 2);

		mid = GameObject.Find(coreName);

		randScale = Random.Range (desiredScale - minMax, desiredScale + minMax);
		actualScale = transform.localScale;
        transform.forward = GameObject.Find("Main Camera").transform.position - transform.position;
		transform.position = transform.position + transform.forward * 3f;

	}

	// Update is called once per frame
	void Update () 
	{
        
		if(actualScale.x < randScale)
		{
			actualScale.x += growSpeed * Time.deltaTime;
			actualScale.y += growSpeed * Time.deltaTime;
			actualScale.z += growSpeed * Time.deltaTime;
			//transform.Rotate (randomRotateX,randomRotateY,randomRotateZ);
		}
		else 
		{
			actualScale.x = randScale;
			actualScale.y = randScale;
			actualScale.z = randScale;
		}

        if(isOrbiting == false)
        {
            dirToCore = transform.position - mid.transform.position;
            dirToCore = dirToCore.normalized;
            transform.localScale = actualScale;
            mid.GetComponent<MoveCore>().ChangeDir(dirToCore);
        }
        else
        {
			//transform.parent = mid.transform;
			
            transform.RotateAround(mid.transform.position, randomRotateX, rotateSpeedX * Time.deltaTime);
			transform.RotateAround(mid.transform.position, randomRotateY, rotateSpeedY * Time.deltaTime);
			transform.RotateAround(mid.transform.position, randomRotateZ, rotateSpeedZ * Time.deltaTime);

			transform.Translate((transform.position - mid.transform.position) * orbitClosingSpeed * Time.deltaTime,Space.World);
        }
       
	}
	public IEnumerator AddCrystal()
	{
		yield return new WaitForSeconds(0.2f);
		Collider[] possibleLights = Physics.OverlapSphere(transform.position, 60f, lightLayer);
		{
			for (int i = 0; i < possibleLights.Length; i++)
			{
				if (possibleLights[i].tag == "Light")
				{
					possibleLight = possibleLights[0].gameObject;
					possibleLight.GetComponent<LightManager>().AddCrystal();
					//Debug.Log("Added a crystal to : " + possibleLights[0].name);
				}
			}
		}	
	}
	public IEnumerator RemoveCrystal()
	{
		if(!dying)
		{
			dying = true;
			yield return new WaitForSeconds(0.2f);
			Collider[] possibleLights = Physics.OverlapSphere(transform.position, 60f, lightLayer);
			{
				for (int i = 0; i < possibleLights.Length; i++)
				{
					if (possibleLights[i].tag == "Light")
					{
						possibleLight = possibleLights[0].gameObject;
						possibleLight.GetComponent<LightManager>().RemoveCrystal();
						//Debug.Log("Removed a Crystal from : " + possibleLights[0].name);
					}
				}
			}
			
		}
		
	}

}
