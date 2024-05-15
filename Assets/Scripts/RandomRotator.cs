using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float maxRotSpeed = 2;
	public bool x, y, z;

	private Vector3 rot;
	private float xRot,yRot,zRot;

	void Start () {
		if (x) {
			xRot = Random.Range (-maxRotSpeed, maxRotSpeed);
		}
		if (y) {
			yRot = Random.Range (-maxRotSpeed, maxRotSpeed);
		}
		if (z) {
			zRot = Random.Range (-maxRotSpeed, maxRotSpeed);
		}

		rot = new Vector3 (xRot, yRot, zRot);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rot);
	}
}
