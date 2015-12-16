using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	GameObject cameraMain;
	GameObject mid;
	public float closestPoint;
	public float duration;
	public float magnitude;
	float actualMagnitude;


	void Start()
	{
		actualMagnitude = magnitude;
		mid = GameObject.Find("CrystalCore");
		cameraMain = GameObject.Find("Main Camera");	
	}

	void Update()
	{
		StartCoroutine(Shake());
		//Debug.Log(Vector3.Distance(transform.position, mid.transform.position));
		//Debug.Log(closestPoint);

	}

	public IEnumerator Shake()
	{

		float elapsed = 0.0f;
		if(Vector3.Distance(transform.position, mid.transform.position) < closestPoint * 3 && Vector3.Distance(transform.position, mid.transform.position) > closestPoint)
		{
			actualMagnitude = magnitude / (Vector3.Distance(transform.position, mid.transform.position) / closestPoint);
        }
		Vector3 originalCamPos = cameraMain.transform.localPosition;
		if (Vector3.Distance(transform.position, mid.transform.position) < closestPoint * 3)
		{

			elapsed += Time.deltaTime;

			float percentComplete = elapsed / duration;
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= actualMagnitude * damper;
			y *= actualMagnitude * damper;

			cameraMain.transform.localPosition = new Vector3(x, y, originalCamPos.z);

			yield return null;
		}

		cameraMain.transform.localPosition = originalCamPos;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Core")
		{
			GameObject.Find("GameController").GetComponent<FadeInAndOut>().StartCoroutine(GameObject.Find("GameController").GetComponent<FadeInAndOut>().FadeOnTp());
		}
	}
}
