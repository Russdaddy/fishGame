using UnityEngine;
using System.Collections;

public class rayScript : MonoBehaviour {
	Color currentColor;
	float fade = 0;
	float brightestState;
	bool fadingIn = true;

	float xPos;

	// Use this for initialization
	void Start () {
		//Debug.Log(GetComponent<Renderer> ().material.color);
		brightestState = Random.Range (.2f, .7f);
		xPos = Random.Range (0, 10);
		GetComponent<Renderer>().material.color = new Color(1,1,1,fade);
	}
	
	// Update is called once per frame
	void Update () {
		xPos -= .006f;

		if (fade < brightestState && fadingIn ==true) {
			fade += .002f;
		} else {
			fadingIn = false;
			fade -= .002f;
		}

		gameObject.transform.position = new Vector3 (xPos, gameObject.transform.position.y, gameObject.transform.position.z);

		GetComponent<Renderer>().material.color = new Color(1,1,1,fade);

		if (fadingIn == false && fade <= 0) {
			Destroy(this.gameObject);
		}
	}
}
