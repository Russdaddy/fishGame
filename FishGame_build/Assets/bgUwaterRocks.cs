using UnityEngine;
using System.Collections;

public class bgUwaterRocks : MonoBehaviour {
	float moveSpeed = .05f;
	public float xPos;
	public float yPos;

	void Setup(){

	}

	// Update is called once per frame
	void Update () {
		//xPos -= moveSpeed;
		//gameObject.transform.position = new Vector3 (xPos, yPos, gameObject.transform.position.z);
		if (this.gameObject.name == "bgUwaterRocks(Clone)") {
			this.gameObject.name = "bgUwaterRocks";
		};

	}

	public void setPosition(float _xPos,float _yPos){
		xPos = _xPos;
		yPos = _yPos;

	}
	public void moveRock(){
		xPos -= moveSpeed;
		gameObject.transform.position = new Vector3 (xPos,yPos,gameObject.transform.position.z);
	}
}
