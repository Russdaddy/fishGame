using UnityEngine;
using System.Collections;

public class bigFishScript : MonoBehaviour {

	float moveSpeed = .04f;
	float xPos = 10;
	float yPos;

	// Use this for initialization
	void Start () {

		if (this.gameObject.name == "bigFish(Clone)") {
			this.gameObject.name = "bigFish";
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
