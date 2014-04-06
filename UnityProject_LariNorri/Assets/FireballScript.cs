using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
	
	//public GameObject theCamera;
	private float life;

	// Use this for initialization
	void Start () {
		life = 0;
		//transform.rotation = theCamera.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * 10);
		life += Time.deltaTime;
		if (life > 3)
			Destroy (gameObject);
	}
}
