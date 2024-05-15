using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[System.Serializable]
public class Fruit{
	public string name;
	public GameObject fruitPic;
	public bool asked;
}

public class LevelController : MonoBehaviour {

	public GameObject canvas,modelContainer;
	public int scoreUpdate=100,totalQuestions=5;
	public AudioClip correctClip, wrongClip, optionDisplayClip,gameEndClip,bkMusicClip;
	public Text scoreText, questionText, endScoreText;
	public Color wrongBtncolor, rightBtnColor;
	public Text[] optionText = new Text[4];
	public GameObject[] optionBtn = new GameObject[4];
	public Button[] btns = new Button[4];
	public List<Fruit> fruit= new List<Fruit>();

	int correctOptionNo,correctFrutNo,score=0,questionNumber=0;
	GameObject currentFruitModel;
	bool gameEnd=false;

	AppController appController;
	Animator anim;
	AudioSource aud,bkAud;

	void Start () {
		appController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AppController> ();
		anim=canvas.GetComponent<Animator>();
		bkAud = this.transform.GetChild (0).transform.gameObject.GetComponent<AudioSource> ();
		aud = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("Music") == 1) {
			bkAud.clip = bkMusicClip;
			bkAud.Play ();
		}
		scoreText.text = "000";
		StartCoroutine (Creator ());
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Handheld.Vibrate ();
			SimpleSceneFader.ChangeSceneWithFade ("Main Menu");
		}
	}

	void QuestionFeed(){
		int[] wrongOption = new int[3];

		correctOptionNo = Random.Range (0, 4);

		do{
			correctFrutNo=Random.Range(0,fruit.Count);
		}while(fruit[correctFrutNo].asked);

		fruit[correctFrutNo].asked=true;

		do {
			wrongOption[0] = Random.Range (0, fruit.Count);
		} while(wrongOption[0] == correctFrutNo);
		do {
			wrongOption[1] = Random.Range (0, fruit.Count);
		} while((wrongOption[1] == correctFrutNo)||(wrongOption[1]==wrongOption[0]));
		do {
			wrongOption[2] = Random.Range (0, fruit.Count);
		} while((wrongOption[2] == correctFrutNo)||(wrongOption[2]==wrongOption[0])||(wrongOption[2]==wrongOption[1]));

		optionText [correctOptionNo].text = fruit [correctFrutNo].name;

		int wrngOpt = 0;
		for (int i = 0; i < 4; i++) {
			if (i != correctOptionNo) {
				optionText [i].text = fruit [wrongOption [wrngOpt]].name;
				wrngOpt++;
			}
		}
	}


	IEnumerator Creator(){

		questionNumber++;

		if (questionNumber <= totalQuestions) {
			QuestionFeed ();

			yield return new WaitForSeconds (0.25f);

			questionText.text = questionNumber.ToString () + ") Identify the fruit :";

			yield return new WaitForSeconds (0.25f);

			if (!gameEnd) {
				Vector3 modelPos = new Vector3 (0, 1, 0);
				modelContainer.SetActive (true);
				currentFruitModel = Instantiate (fruit [correctFrutNo].fruitPic, modelPos, Quaternion.identity)as GameObject;

				for (int i = 0; i < 4; i++) {
					yield return new WaitForSeconds (0.25f);
					if (PlayerPrefs.GetInt ("Sound") == 1) {
						aud.clip = optionDisplayClip;
						aud.Play ();
					}
					optionBtn [i].GetComponent<Image> ().color = Color.white;
					optionBtn [i].SetActive (true);
					btns [i].interactable = false;
				}
				for (int j = 0; j < 4; j++) {
					btns [j].interactable = true;
				}
			}
		}

		else {
			yield return null;
			gameEnd = true;
			StartCoroutine (GameEnd ());
		}
			
	}

	void Destroyer(){
		Destroy (currentFruitModel);
		modelContainer.SetActive (false);
		questionText.text="";
		for(int i=0;i<4;i++){
			optionText[i].text=" ";
			optionBtn [i].SetActive (false);
		}

		StartCoroutine (Creator ());
	}


	IEnumerator CorrectAnswer(){
		score = score + scoreUpdate;
		scoreText.text = score.ToString ();
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			aud.clip = correctClip;
			aud.Play ();
		}
		anim.SetTrigger ("right");
		yield return new WaitForSeconds (1);
		Destroyer ();
	}

	IEnumerator WrongAnswer(int pressedBtnIndex){
		Handheld.Vibrate ();
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			aud.clip = wrongClip;
			aud.Play ();
		}
		optionBtn [correctOptionNo].GetComponent<Image> ().color = rightBtnColor;
		optionBtn [pressedBtnIndex].GetComponent<Image> ().color = wrongBtncolor;
		anim.SetTrigger ("wrong");
		yield return new WaitForSeconds (1f);
		Destroyer ();
	}


	public void OptionBtns(int btnNo){
		appController.UIAudio ();
		for (int i = 0; i < 4; i++) {
			btns [i].interactable = false;
		}
		if (btnNo == correctOptionNo) {
			StartCoroutine (CorrectAnswer ());
		}
		else {
			StartCoroutine (WrongAnswer (btnNo));
		}
	}


	IEnumerator GameEnd(){
		modelContainer.SetActive (false);
		if (PlayerPrefs.GetInt ("Music") == 1) {
			bkAud.volume = 0.4f;
		}
		yield return new WaitForSeconds(0.20f);
		questionText.text="GAME OVER ...";
		yield return new WaitForSeconds(0.25f);
		endScoreText.text = score.ToString ()+"/"+(totalQuestions*scoreUpdate).ToString();
		anim.SetTrigger ("gameEnd");
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			aud.clip = gameEndClip;
			aud.Play ();
		}
	}

	public void BackBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		SimpleSceneFader.ChangeSceneWithFade ("Main Menu");
	}

	public void RestartBtn(){
	    appController.UIAudio ();
		Handheld.Vibrate ();
		SceneManager.LoadScene ("Game");
	}
		

}
