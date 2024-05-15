using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Txt{
	public string aboutText;
	public Text textContainer;
}

public class AboutController : MonoBehaviour {

	public Txt[] txt;
	public float speed = 0.1f;
	public AudioClip bkMusicClip;

	AudioSource musicAud;
	AppController appController;

	void Start () {
		appController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AppController> ();
		musicAud = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("Music") == 1) {
			musicAud.clip = bkMusicClip;
			musicAud.Play ();
		} 
		StartCoroutine (WordAppear ());
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Handheld.Vibrate ();
			SimpleSceneFader.ChangeSceneWithFade ("Main Menu");
		}
	}

	IEnumerator WordAppear(){
		int count = 0;
		while (count < txt.Length) {
			txt [count].textContainer.text = "";
			for (int i = 0; i < txt[count].aboutText.Length; i++) {
				txt[count].textContainer.text =txt[count].textContainer.text+txt[count].aboutText [i].ToString();
				yield return new WaitForSeconds (speed);
			}
			count++;
		}
	}

	public void DownloadARAppBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		Application.OpenURL ("https://drive.google.com/file/d/1WE6ICtfNGE7-mGFZ0_pLp4k9ATFPo8Z8/view?usp=sharing");
	}

	public void BackBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		SimpleSceneFader.ChangeSceneWithFade ("Main Menu");
	}
}
