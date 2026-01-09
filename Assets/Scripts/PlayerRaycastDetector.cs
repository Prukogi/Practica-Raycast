using UnityEngine;
using System;

public class PlayerRaycastDetector : MonoBehaviour
{
	#region Properties
	RaycastHit hit;
	GameObject lastHitObject;
	Color lastHitOriginalColor;
	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks

	void Start()
    {
        
    }


	void Update()
	{
		// Draw the ray so we can see it in the Scene view
		Debug.DrawRay(transform.position, transform.forward * 3f, Color.black);

		// Cast a ray forward
		if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
		{
			// If we are hitting a different object than last frame
			if (lastHitObject != hit.collider.gameObject)
			{
				// Restore color of previous object
				if (lastHitObject != null)
				{
					Renderer lastRend = lastHitObject.GetComponent<Renderer>();
					if (lastRend != null)
						lastRend.material.color = lastHitOriginalColor;
				}

				// Store and change color of the new object
				Renderer rend = hit.collider.GetComponent<Renderer>();
				if (rend != null)
				{
					lastHitOriginalColor = rend.material.color; // store ORIGINAL color
					rend.material.color = Color.blue;           // change color to blue
				}

				// Save new object as last hit
				lastHitObject = hit.collider.gameObject;
			}

			Debug.Log("Hit: " + hit.collider.name);
		}
		else
		{
			// If we are not hitting anything, restore last object
			if (lastHitObject != null)
			{
				Renderer lastRend = lastHitObject.GetComponent<Renderer>();
				if (lastRend != null)
					lastRend.material.color = lastHitOriginalColor;

				lastHitObject = null;
			}
		}
	}
	#endregion




	#region Public Methods
	#endregion

	#region Private Methods
	#endregion

}
