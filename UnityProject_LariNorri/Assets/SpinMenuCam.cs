using UnityEngine;
using System.Collections;

public class SpinMenuCam : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		this.transform.Rotate( new Vector3( 0, Time.deltaTime, 0));

	}
}
