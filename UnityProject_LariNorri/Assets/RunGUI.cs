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
	}
}
