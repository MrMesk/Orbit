using UnityEngine;
using System.Collections;

public class FadeInAndOut : MonoBehaviour {

	public Texture2D blackScreen; // add a black texture here
	public float fadeTime; // how long you want it to fade?
	
	private bool fadeIn; // false for fade out
	private Color color = Color.black;
	private float timer;
	
	public void FadeIn()
	{
		timer = fadeTime;
		fadeIn = true;
	}
	
	public void FadeOut()
	{
		timer = fadeTime;
		fadeIn = false;
	}
	
	protected void Start()
	{
		FadeIn();
	}
	
	protected void OnGUI()
	{
		if (fadeIn)
		{
			color.a = timer / fadeTime;
		}
		else
		{
			color.a = 1 - (timer / fadeTime);
		}
		
		GUI.color = color;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackScreen);
	}
	
	protected void Update()
	{
		timer -= Time.deltaTime;
		
		if (timer <= 0)
		{
			timer = 0;
		}
	}

	public IEnumerator FadeOnTp()
	{
		FadeOut();

		yield return new WaitForSeconds(fadeTime);

		GameObject rotor = GameObject.Find("Rotor");
		Quaternion randomRot;
		randomRot = Quaternion.Euler(rotor.transform.rotation.x + Random.Range(90, 270), rotor.transform.rotation.y + Random.Range(90, 270), rotor.transform.rotation.z + Random.Range(90, 270));
		rotor.transform.rotation = randomRot;

		yield return new WaitForSeconds(fadeTime);

		FadeIn();
	}
}
