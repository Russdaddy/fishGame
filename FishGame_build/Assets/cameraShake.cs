using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {

	public float ShakeAmount = 0.25f;
	public float DecreaseFactor = 1.0f;

	private new Camera camera;
	private Vector3 cameraPos = new Vector3 (0, 0, -10);
	private float shake = 0.0f;
	
	void Awake() {
		this.camera = GetComponent<Camera>();

		if (this.camera == null) {
			Debug.Log("CameraShake:unable to find camera");
		}
	}
	void Update() {
		if (this.shake > 0.0f) {
			this.camera.transform.localPosition = Random.insideUnitSphere * this.ShakeAmount * this.shake;
			this.shake = Time.deltaTime * this.DecreaseFactor;
		}

		if (this.shake <= 0.0f) {
			this.shake = 0.0f;
			this.camera.transform.localPosition = this.cameraPos;
		}
	}
	public void Shake(float amount) {
		if (this.shake <= 0.0f) {
			this.cameraPos = this.camera.transform.position;
		}

		this.shake = amount;
	}
}
