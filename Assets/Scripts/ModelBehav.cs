using UnityEngine;
using System.Collections;

public class ModelBehav : MonoBehaviour {


	public GameObject effect1,effect2;

	public void OnTrackingFound(){
		GameObject effect;
		Vector3 pos = new Vector3 (0, 0, 0);
		effect=Instantiate (effect2, pos, Quaternion.identity)as GameObject;
		Destroy (effect, 2);
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			effect.GetComponent<AudioSource> ().Play ();
		}
	}

	public void OnTrackingLost(){
		GameObject effect;
		Vector3 pos = new Vector3 (0, 0, 0);
		effect=Instantiate (effect1, pos, Quaternion.identity)as GameObject;
		Destroy (effect, 2);
		if (PlayerPrefs.GetInt ("Sound") == 1) {

			effect.GetComponent<AudioSource> ().Play ();
		}
	}

}
