using UnityEngine;
using System.Collections.Generic;

public class gameScript : MonoBehaviour {

	public int health;
	public GameObject background;
	public Camera gameCamera;
	float cameraYShift;
	float cameraShiftSpeed;
	Vector3 mousePosition;

	public GameObject smallFish;
	int smallfishTimer = 180;

	public GameObject bigFish;
	int bigfishTimer = 150;

	public GameObject ray;
	int rayTimer = 50;

	Vector3 foregroundPos;
	float[] yShifts = new float[2];
	string[] shiftDirections = new string[2];

	void Start(){
		shiftDirections[0]= "down";
		//initialize the cameraYShift
		cameraYShift = gameCamera.gameObject.transform.position.y;
	}

	// Update is called once per frame
	void Update () {

		rayTimer -= 1;
		if (rayTimer == 0) {
			Instantiate(ray, new Vector3(Random.Range(0,10),4.0f,ray.gameObject.transform.position.z),Quaternion.Euler(new Vector3(0,0,Random.Range(-14,-3))));
			rayTimer = Random.Range(100,200);
		}

		//span small fish on timer
		smallfishTimer -= 1;
		if (smallfishTimer == 0) {
			Instantiate(smallFish,new Vector3(10,1,-1),Quaternion.identity);
			smallfishTimer = 180;
		}

		//spawn big fish on timer
		bigfishTimer -= 1;
		if (bigfishTimer == 0) {
			Instantiate(bigFish,new Vector3(10,1,-1),Quaternion.identity);
			bigfishTimer = 150;
		}

		/*Debug.Log(Mathf.Round(background.transform.position[1] * 10f) / 10f);
		//background bounce
		if ((Mathf.Round(background.transform.position[1] * 10f) / 10f) == 0f) {
			shiftDirections[1] = "down";
		}
		if ((Mathf.Round(background.transform.position[1] * 10f) / 10f) == -.2f){
			shiftDirections[1] = "up";
		}*/

		//move the camera from its current position towards the yshifted position
		gameCamera.transform.position = Vector3.MoveTowards(new Vector3(gameCamera.transform.position.x,gameCamera.transform.position.y,gameCamera.transform.position.z),new Vector3(0, cameraYShift, -10),1f);

		//if mouse button is clicked
		if (Input.GetMouseButton(0)) {
			//if the mouse is on the top of the screen
			if (Input.mousePosition.y > 400 && gameCamera.transform.position.y < 4.0f){
				if (cameraShiftSpeed < .1){
					cameraShiftSpeed += .007f;
				}
				cameraYShift += cameraShiftSpeed;
			}
			//if the mouse is on the bottom of the screen
			if (Input.mousePosition.y < 70 && gameCamera.transform.position.y > 0f){
				if (cameraShiftSpeed < .1){
					cameraShiftSpeed += .007f;
				}
				cameraYShift -= cameraShiftSpeed;
			}
		}

		//if the mouse button is released
		if (Input.GetMouseButtonUp (0)) {
			//stop shifting the camera
			cameraShiftSpeed = 0;
		}

		//background bounce
		if (shiftDirections [1] == "up") {
			yShifts[1] += .0018f;
		}
		if (shiftDirections [1] == "down") {
			yShifts[1] -= .0018f;
		}
		//background.transform.position = new Vector3 (background.transform.position.x, yShifts[1], background.transform.position.z);

	}

}
