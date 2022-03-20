/*
 *	File: CameraController.cs
 *	Author: foldybox
 *	Description: The script controls the movement of the camera. It smoothly follows the 
 *	target object. You can set up dumping, mouse dependency ratio and offset.
 */

using UnityEngine;

public class CameraController : MonoBehaviour {
	// Serialized public fields
	[SerializeField]
	public Transform targetObject;
	[SerializeField]
	public float cameraDumping = 1.5f;
	[SerializeField]
	public float mouseDependence = 0.2f;
	[SerializeField]
	public Vector2 offset = new Vector2(0f, 0f);

    private void FixedUpdate() {
		// Take mouse world position
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Calculate final target position
		Vector3 target = new Vector3(targetObject.position.x + offset.x + mousePos.x * mouseDependence, targetObject.position.y + offset.y + mousePos.y * mouseDependence, transform.position.z);

		// Set camera new position with linear interpolation for 
		transform.position = Vector3.Lerp(transform.position, target, cameraDumping * Time.fixedDeltaTime);
    }
}


