using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

	float moveSpeed = 0;
	bool startMoving = false;
	Vector3 targetPos;

	// Use this for initialization
	void Start () {
		targetPos = new Vector3 (0, 0, 0);
		targetPos.z = transform.position.z;
	}

	// Update is called once per frame
	void Update () {

		float distanceToMouseX = Mathf.Floor (Vector2.Distance (new Vector2 (transform.position.x, transform.position.y), new Vector2 (transform.position.x, targetPos [1])));
		//Debug.Log (distanceToMouseX);
		//flip sprite to look right
		if (targetPos [1] > transform.position.y) {
			//QUATERNION ROTATION = (Z,X,Y)
			gameObject.transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, -5));
		}
		if (targetPos [1] < transform.position.y) {
			gameObject.transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, 5));
		}
	
		//set moving variable to true or false based on mouse click/release
		if (Input.GetMouseButtonDown(0)) {
			startMoving = true;
		}
			
		if (Input.GetMouseButtonUp(0)) {
			startMoving = false;
		}
		//always move by the speed of variable moveSpeed towards the current x position and the target y and z position
		transform.position = Vector3.MoveTowards (transform.position, new Vector3(transform.position.x,targetPos.y,transform.position.z), moveSpeed * Time.deltaTime);

		//character movement ceiling
		if (Mathf.FloorToInt(transform.position[1])== 4.0){
			transform.position = new Vector3(transform.position.x,4.0f,transform.position.z);
		}

		//PLAYER MOVEMENT
		//if startMoving is true, start to speed up
		if (startMoving == true) {
			//mouse is far from player sprite
			if(distanceToMouseX > 1.0){
				if (moveSpeed < 3f){
					moveSpeed += .05f;
				}

			}
			//mouse is mid-dist from player sprite
			else if (distanceToMouseX > .8){
				if (moveSpeed < 3f){
					moveSpeed += .04f;
				}

			}
			//mouse is close to player sprite
			else {
				if (moveSpeed > 0){
					moveSpeed -= .038f;
				}

			}
			targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}

		if (transform.position.y == targetPos[1]) {
			moveSpeed = 0;
		}
	
		//if startMoving is false, start to slow down
		if (startMoving == false) {
			if (moveSpeed > 0){
				moveSpeed -= .05f;
			}
		}

		targetPos.z = transform.position.z;

	}

	//collision detection
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "smallFish") {
			Debug.Log("POWERRR!!");
			//increase player scale
			gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + .01f,gameObject.transform.localScale.y + .01f,gameObject.transform.localScale.z + .01f);
			//move player a bit to the right
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + .1f,gameObject.transform.position.y,gameObject.transform.position.z);
			Destroy (col.gameObject);
		}

		if (col.gameObject.name == "bigFish") {
			//dead
			Destroy(this.gameObject);
		}
	}

}



