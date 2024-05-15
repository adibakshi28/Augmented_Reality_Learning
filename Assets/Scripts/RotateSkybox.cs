using UnityEngine;
using System.Collections;

public class RotateSkybox : MonoBehaviour {

	public float rotation; 
	private Skybox skybox;

	void Start () {
		skybox = GetComponent<Skybox> ();
	}
	void Update () {
		rotation -= Time.deltaTime*5;
		skybox.material.SetFloat ("_Rotation", rotation);
	}
}