using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	public LocationInfo origin;

	// Use this for initialization
	void Start () {
		Input.location.Start (1,1);
		origin = Input.location.lastData;
	}
	
	// Update is called once per frame
	void Update () {

		// shift platform a little but when the user moves around
		LocationInfo curr = Input.location.lastData;

		float diffX = curr.latitude - origin.latitude * 1; 
		float diffZ = curr.longitude - origin.longitude * 1; 

		// not sure how I'm going to test this...
		gameObject.transform.position = new Vector3(diffX,0,diffZ);
	}

	void OnDisable() {
		//Input.location.Stop ();
		//prevLoc = Input.location.lastData;
	}
}
