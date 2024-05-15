using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

	public int versionNo ;
	public AudioClip UIAudioClip;

	AudioSource aud;

	void Start () {
		aud = GetComponent<AudioSource> ();

		if (PlayerPrefs.GetInt ("HasPlayed") < 1) {
			PlayerPrefs.SetInt ("Sound", 1);
			PlayerPrefs.SetInt ("Music", 1);
			PlayerPrefs.SetInt ("HasPlayed", 100);
		}
		PlayerPrefs.SetInt("timesLaunched",(PlayerPrefs.GetInt("timesLaunched")+1));     //  incriments by 1 every time the application is launched 

		if (!(PlayerPrefs.GetInt ("version") == versionNo)) {
			PlayerPrefs.SetInt ("version", versionNo);
			//  put all the new player pref statements or changes to previously existant in future versions here eg. new players , coin gifts etc
		}

			
		DontDestroyOnLoad (this.gameObject);
		SceneManager.LoadScene ("Main Menu");
	}


	public void UIAudio(){
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			aud.clip = UIAudioClip;
			aud.Play ();
		}
	}
}
