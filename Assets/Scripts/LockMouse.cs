using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour
{
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
}
