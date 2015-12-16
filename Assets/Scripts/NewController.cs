using UnityEngine;
using System.Collections;

public class NewController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

	void Update ()
    {
       
        transform.up = transform.position - Vector3.zero;
        if (Input.GetAxis("Horizontal") != 0f)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal") * -1f));
        }
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
    }
}
