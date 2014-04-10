using UnityEngine;
using System.Collections;

public class InGameGUI : MonoBehaviour {

	// tha various spheres we will knock off the platform 
	public GameObject Moe,Larry,Curly;

	private float countDown;
	private bool winnar; // lets us share the win state with camera controller

	// tells other scripts the state of the game
	public bool GamePaused() {
		return winnar || countDown < 0 || countDown > 60;
	}

	void Start() {
		countDown = 60.999f; // 1 minute
		winnar = false;
		Input.location.Start (1,1);
	}

	// Use this for initialization
	void OnGUI () {

		// size of window?
		int centerX = Screen.width / 2;
		int centerY = Screen.height / 2;
		string title = "Knock the Smileys off the Platform!!!";

		// display GPS data in game HUD
		// using the GPS feature
		GUI.color = new Color(0,0,0);
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
	
		// build components for main menu
		GUI.color = new Color(1,0,0);
		
		//GUI.matrix = Matrix4x4.Scale (new Vector3 (2, 2, 1));
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.skin.label.fontSize = 20;
		GUI.Label(new Rect (centerX - 300, centerY - 190, 600, 50), title);

		// clheck if you won!
		if (countDown > 0 && 
		    Moe.transform.position.y < 0 && 
			Larry.transform.position.y < 0 &&
			Curly.transform.position.y < 0)
				winnar = true;
		else
			// tick down the time
			countDown -= Time.deltaTime;

		if(winnar)// win button
		{
			GUI.skin.button.fontSize = 30;
			GUI.color = new Color(0,1,0);
			GUI.backgroundColor = new Color (0, 1, 0, 1);
			if (GUI.Button (new Rect (centerX - 120, centerY-25, 240, 50), "YOU WIN!!!"))
				Application.LoadLevel(0);
		}
		// lose condition & display
		if(countDown > 0)
		{
			GUI.skin.label.fontSize = 40;
			GUI.Label(new Rect (centerX - 300, centerY - 150, 600, 50), ((int)countDown).ToString());
		}
		else // we lost
		{
			GUI.skin.button.fontSize = 30;
			GUI.color = new Color(1,0,0);
			GUI.backgroundColor = new Color (1, 0, 0, 1);
			if (GUI.Button (new Rect (centerX - 120, centerY-25, 240, 50), "YOU LOSE..."))
				Application.LoadLevel(0);
		}

	}

}
