using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public AudioClip bkMusicClip;
	public GameObject musicOnPic, musicOffPic, soundOnPic, soundOffPic;

	AppController appController;
	AudioSource musicAud;

	void Start () {
		appController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AppController> ();
		musicAud = GetComponent<AudioSource> ();

		if (PlayerPrefs.GetInt ("Music") == 1) {
			musicAud.clip = bkMusicClip;
			musicAud.Play ();
			musicOffPic.SetActive (false);
			musicOnPic.SetActive (true);
		} 
		else {
			musicOffPic.SetActive (true);
			musicOnPic.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("Sound") == 1) {
			soundOffPic.SetActive (false);
			soundOnPic.SetActive (true);
		} 
		else {
			soundOffPic.SetActive (true);
			soundOnPic.SetActive (false);
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit (); 
		}
	}

	public void ARSceneBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		SimpleSceneFader.ChangeSceneWithFade ("Main_scene");
	}

	public void QuizSceneBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		SimpleSceneFader.ChangeSceneWithFade ("Fruit_Attack");
	}

	public void GameSceneBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		SimpleSceneFader.ChangeSceneWithFade ("Game");
	}


	public void MusicToggleBtn(){
		appController.UIAudio ();
		if (PlayerPrefs.GetInt ("Music") == 1) {
			PlayerPrefs.SetInt ("Music", 0);
			musicAud.Stop ();
			musicOffPic.SetActive(true);
			musicOnPic.SetActive (false);
		} 
		else {
			PlayerPrefs.SetInt ("Music", 1);
			musicAud.clip = bkMusicClip;
			musicAud.Play ();
			musicOffPic.SetActive (false);
			musicOnPic.SetActive (true);
		}
	}

	public void SoundToggleBtn(){
		appController.UIAudio ();
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			PlayerPrefs.SetInt ("Sound", 0);
			soundOffPic.SetActive (true);
			soundOnPic.SetActive (false);
		} 
		else {
			PlayerPrefs.SetInt ("Sound", 1);
			appController.UIAudio ();
			soundOffPic.SetActive (false);
			soundOnPic.SetActive (true);
		}
	}

	public void HowToBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		SimpleSceneFader.ChangeSceneWithFade ("About");
	}

	public void ExitBtn(){
		appController.UIAudio ();
		Application.Quit(); 
	}

}
