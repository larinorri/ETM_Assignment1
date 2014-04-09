using UnityEngine;
using System.Collections;

public class LaunchFireBallScript : MonoBehaviour {

	public GameObject fireballToLaunch;
	private InGameGUI gameLogic;
	// Use this for initialization
	void Start () {
		GameObject search = GameObject.Find("PlayLogic");
		gameLogic = search.GetComponent<InGameGUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (gameLogic.GamePaused ()) 
			return;

		if (Input.GetMouseButtonDown (0)) {
			GameObject fball = (GameObject)Instantiate (fireballToLaunch);
			fball.transform.rotation = transform.rotation;
		}

	}
}
