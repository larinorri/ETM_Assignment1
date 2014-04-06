using UnityEngine;
using System.Collections;

public class LaunchFireBallScript : MonoBehaviour {

	public GameObject fireballToLaunch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			GameObject fball = (GameObject)Instantiate (fireballToLaunch);
			fball.transform.rotation = transform.rotation;
		}

	}
}
