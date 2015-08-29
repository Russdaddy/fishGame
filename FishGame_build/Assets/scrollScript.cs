using UnityEngine;
using System.Collections;

public class scrollScript : MonoBehaviour {
	public float speed = 0;
	public static scrollScript current;
	float pos = 0;

	void Start(){
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		pos += speed;
		if (pos > 1.0f) {
			pos -= 1.0f;
		}
		//move background so it wraps infinitely
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (pos ,0);
	}
}
