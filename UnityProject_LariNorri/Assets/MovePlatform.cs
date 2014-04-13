using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	public LocationInfo origin;
	private bool initialized;

	// Use this for initialization
	void Start () {
		Input.location.Start ();
		initialized = false;
		//origin = Input.location.lastData;
	}
	
	// Update is called once per frame
	void Update () {

		if(initialized)
		{
			// shift platform a little but when the user moves around
			LocationInfo curr = Input.location.lastData;

			float diffX = (curr.latitude - origin.latitude) * 20000; 
			float diffZ = (curr.longitude - origin.longitude) * 20000; 

			// this works but GPS in this version of unity is a bit iffy on WP8, unity 4.5 will improve it.
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
