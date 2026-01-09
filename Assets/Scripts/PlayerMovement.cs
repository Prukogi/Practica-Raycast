using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
	#region Properties
	public float movementSpeed = 5;
	public float rotationSpeed = 10;
	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks
    void Update()
    {
		//Movement
		transform.Translate(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime * Vector3.right);
		transform.Translate(Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime * Vector3.forward);

		//Sprint
		if (Input.GetKey(KeyCode.LeftShift))
			movementSpeed = 10;
		if (Input.GetKeyUp(KeyCode.LeftShift))
			movementSpeed = 5;
		//Rotation
		if (Input.GetKey(KeyCode.Q))transform.Rotate(rotationSpeed * Time.deltaTime * -Vector3.up);
		if (Input.GetKey(KeyCode.E)) transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
	}

	#endregion





	#region Public Methods
	#endregion

	#region Private Methods
	
	#endregion

}
