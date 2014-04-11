using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	// Lnorri This is a base unity script customized to support tilt sensors & pausing for game play
	private InGameGUI gameLogic;

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 8F;
	public float sensitivityY = 8F;

	// limit rotation to look ahead
	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;
	float rotationX = 0F;

	void Update ()
	{
		// freeze the camera when the game ends
		if (gameLogic.GamePaused ()) 
			return;

		// if no tilt information is present we use mouse/finger dragging input
		if(Input.acceleration.magnitude != 0)
		{
			//float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			rotationX += Input.acceleration.x * sensitivityX;
			rotationX = Mathf.Clamp (rotationX, minimumX, maximumX); // had to add this
			
			rotationY += Input.acceleration.y * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else // use mouse/finger for camera
		{
			if (axes == RotationAxes.MouseXAndY) // this is the only one that gets used
			{
				//float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
				rotationX = Mathf.Clamp (rotationX, minimumX, maximumX); // had to add this

				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			else if (axes == RotationAxes.MouseX)
			{
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}
		}
	}
	
	void Start ()
	{
		// link to logic contoller
		GameObject search = GameObject.Find("PlayLogic");
		gameLogic = search.GetComponent<InGameGUI>();

		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}