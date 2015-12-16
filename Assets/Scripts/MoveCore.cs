using UnityEngine;
using System.Collections;

public class MoveCore : MonoBehaviour
{
    Vector3 dir;
    public float speed;
	// Use this for initialization
	void Start ()
    {
        dir = Vector3.zero;
	}

    void FixedUpdate()
    {
        GameObject[] crystals;
        crystals = GameObject.FindGameObjectsWithTag("Crystal");
        if (crystals.Length < 3)
        {
            dir = (Vector3.zero - transform.position).normalized * 10;
        }
        transform.Translate(dir * Time.deltaTime * speed, Space.World);
        dir = Vector3.zero;
    }

    public void ChangeDir(Vector3 addedDir)
    {
        dir += addedDir;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            other.GetComponent<Grow>().isOrbiting = true;
			other.GetComponent<Grow>().StartCoroutine(other.GetComponent<Grow>().RemoveCrystal());
			other.transform.parent = transform;
        }
    }
}
