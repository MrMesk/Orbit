using UnityEngine;
using System.Collections;

public class MyRotationCamera : MonoBehaviour {


    public float rotationSpeed;
    public float minimumX;
    public float maximumX;
    public float minimumY;
    public float maximumY;

    private float verticalRotation;
    private float horizontalRotation;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
        verticalRotation += Input.GetAxis("Mouse Y") * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, minimumY, maximumY);


        horizontalRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        horizontalRotation = Mathf.Clamp(horizontalRotation, minimumX, maximumX);

        transform.localEulerAngles = new Vector3 (verticalRotation ,- horizontalRotation , 180);

    }
}
