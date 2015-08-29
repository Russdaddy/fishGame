using UnityEngine;
using System.Collections;

public class smallFishScript : MonoBehaviour {

	float moveSpeed = .08f;
	float xPos = 10;
	float yPos;
	
	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "smallFish(Clone)") {
			this.gameObject.name = "smallFish";
		};
		//spit out fish at a random Y-axis range
		yPos = Random.Range (-6f, 4.5f);
	}
	
	// Update is called once per frame
	void Update () {
		//move left
		xPos -= moveSpeed;
		gameObject.transform.position = new Vector3 (xPos,yPos,-1f);

		if (gameObject.transform.position.x < -11f) {
			Destroy(this.gameObject);
		};
	}
}
