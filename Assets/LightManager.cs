using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour
{
	public int crystalNb = 0;
	public int threshold1 = 5;
	public int threshold2 = 20;
	public int threshold3 = 50;
	public int threshold4 = 100;
	public string colorBase;
	int tier;

	GameObject lightChild;
	GameObject baseChild;

	// Use this for initialization
	void Start ()
	{
		lightChild = transform.Find("Light").gameObject;
		baseChild = transform.Find("Basis").gameObject;
		lightChild.transform.Find("ParticleEmitter").gameObject.SetActive(false);
		tier = 0;
		StateCheck();
	}

	void ColorChange()
	{
		string colorName = string.Concat("CrystalTexture/" + colorBase);
		
		switch (tier)
		{
            
			case 0:
				colorName = string.Concat(colorName + "T0");
				lightChild.transform.Find("ParticleEmitter").gameObject.SetActive(false);
				break;

			case 1:
				colorName = string.Concat(colorName + "T1");
				lightChild.transform.Find("ParticleEmitter").gameObject.SetActive(false);
				break;

			case 2:
				colorName = string.Concat(colorName + "T2");
				lightChild.transform.Find("ParticleEmitter").gameObject.SetActive(false);
				break;

			case 3:
				colorName = string.Concat(colorName + "T3");
				lightChild.transform.Find("ParticleEmitter").gameObject.SetActive(false);
				break;

			case 4:
				colorName = string.Concat(colorName + "T4");
				lightChild.transform.Find("ParticleEmitter").gameObject.SetActive(true);
				break;

		}

		lightChild.GetComponent<MeshRenderer>().material = Resources.Load(colorName, typeof(Material)) as Material;
		lightChild.GetComponent<Light>().intensity = 1 + tier * 0.25f;

		Material[] mats = baseChild.GetComponent<MeshRenderer>().materials;
		mats[0] = Resources.Load(colorName, typeof(Material)) as Material;
		baseChild.GetComponent<MeshRenderer>().materials = mats;

		if(tier == 4)
		{
			baseChild.GetComponent<Rotation>().enabled = true;
		}
		else
		{
			baseChild.GetComponent<Rotation>().enabled = false;
		}

	}
	void StateCheck()
	{
		if (crystalNb >= threshold4)
		{
			if(tier !=4)
			{
				tier = 4;
				ColorChange();
			}
			
		}
		else if (crystalNb >= threshold3)
		{
			if (tier != 3)
			{
				tier = 3;
				ColorChange();
			}
		}
		else if (crystalNb >= threshold2)
		{
			if (tier != 2)
			{
				tier = 2;
				ColorChange();
			}
		}
		else if (crystalNb >= threshold1)
		{
			if (tier != 1)
			{
				tier = 1;
				ColorChange();
			}
		}
		else
		{
			if (tier != 0)
			{
				tier = 0;
				ColorChange();
			}
		}

	}
	public void AddCrystal()
	{
		crystalNb += 1;
		StateCheck();
	}

	public void RemoveCrystal()
	{
		crystalNb -= 1;
		StateCheck();
	}
}
