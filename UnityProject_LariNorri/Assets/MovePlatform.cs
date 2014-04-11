using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	public LocationInfo origin;
	private bool initialized;

	// Use this for initialization
	void Start () {
		Input.location.Start (1,1);
		initialized = false;
		//origin = Input.location.lastData;
	}
	
	// Update is called once per frame
	void Update () {

		if(initialized)
		{
			// shift platform a little but when the user moves around
			LocationInfo curr = Input.location.lastData;

			float diffX = (curr.latitude - origin.latitude) * 10000; 
			float diffZ = (curr.longitude - origin.longitude) * 10000; 

			// not sure how I'm going to test this...
			gameObject.transform.position = new Vector3(diffX,0,diffZ);
		}
		else if(Input.location.status != LocationServiceStatus.Failed || 
		        Input.location.status != LocationServiceStatus.Initializing)
		{
			initialized = true;
			origin = Input.location.lastData;
		}
	}

	void OnDisable() {
		//Input.location.Stop ();
		//prevLoc = Input.location.lastData;
	}
}
