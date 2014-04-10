using UnityEngine;
using System.Collections;

public class RunGUI : MonoBehaviour {

	// called once per frame
	void OnGUI () {

		// size of window?
		int centerX = Screen.width / 2;
		int centerY = Screen.height / 2;
		string title = "Lari Norri MGMS ETM Unity Project 04/04/2014";

		// build components for main menu
		GUI.color = new Color(0,0,0);

		//GUI.matrix = Matrix4x4.Scale (new Vector3 (2, 2, 1));
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.skin.label.fontSize = 20;
		GUI.Label(new Rect (centerX - 300, centerY - 100, 600, 50), title);

		// make a button to start the game
		GUI.skin.button.fontSize = 30;
		GUI.backgroundColor = new Color (0, 1, 1, 0.25f);
		if (GUI.Button (new Rect (centerX - 150, centerY, 300, 50), "START GAME")) {
			Application.LoadLevel(1);

		}

		// using the GPS feature
		GUI.skin.label.fontSize = 20;
		GUI.skin.label.alignment = TextAnchor.MiddleLeft;

		string gpsStatus = (Input.location.isEnabledByUser) ? "Enabled" : "Disabled";
		GUI.Label(new Rect (Screen.width - 150, Screen.height - 30, 150, 30), "GPS is " + gpsStatus);

		if (Input.location.isEnabledByUser) 
		{
			// display current results
			GUI.Label(new Rect (5, Screen.height - 60, 200, 40), "Latitude:\t\t" + 
			          Input.location.lastData.latitude.ToString());
			GUI.Label(new Rect (5, Screen.height - 35, 200, 40), "Longitude:\t" + 
			          Input.location.lastData.longitude.ToString());
		}

	}

	void Start() {
		Input.location.Start (1,1);
	}
	void OnDisable() {
		//Input.location.Stop ();
	}
}
