using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EZCameraShake;

[System.Serializable]
public class FruitPrefab{
	public GameObject fruitModel;
	public string fruitName;
	public bool slash;
}

public class FruitSpawner : MonoBehaviour {

	public List<FruitPrefab> fruitPrefab = new List<FruitPrefab> ();
	public Transform[] spawnPoints;
	public float minDelay = .1f;
	public float maxDelay = 1f;
	public GameObject canvas, hitAudioHandler;
	public Image[] heartImg;
	public Text scoreText, slashText, gameOverScoreText, pauseSlashText;
	public int scoreIncriment = 100;
	public AudioClip slashClip, gameOverClip, lifeReduceClip,fruitLaunchClip , backGroundClip;

	private int score = 0,noOfLives = 3,fruit1,fruit2;
	private bool gameOver = false, paused=false;

	Animator anim;
	AudioSource aud,bkAud,fruitLaunchAud,hitAud;
	AppController appController;

	void Start () {
		appController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AppController> ();
		anim = canvas.GetComponent<Animator>();
		aud = GetComponent<AudioSource> ();
		hitAud = hitAudioHandler.GetComponent<AudioSource> ();
		bkAud = this.gameObject.transform.GetChild (0).transform.gameObject.GetComponent<AudioSource> ();
		fruitLaunchAud = this.gameObject.transform.GetChild (1).transform.gameObject.GetComponent<AudioSource> ();
		FruitSelector ();
		scoreText.text = score.ToString ();
		slashText.text = "Do not slash ";
		for (int i = 0; i < fruitPrefab.Count; i++) {
			if (fruitPrefab [i].slash) {
				slashText.text = slashText.text + fruitPrefab [i].fruitName + "s, ";
			}
		}
		pauseSlashText.text = slashText.text;
		anim.SetTrigger ("Start");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 1;
			Handheld.Vibrate ();
			SimpleSceneFader.ChangeSceneWithFade ("Main Menu");
		}
	}

	void FruitSelector(){    // 2,3 fruits are selected at a time
		fruit1 = Random.Range(0, fruitPrefab.Count);
		do {
			fruit2 = Random.Range(0, fruitPrefab.Count);
		} while(fruit2 == fruit1);
			
		fruitPrefab [fruit1].slash = true;
		fruitPrefab [fruit2].slash = true;
	}

	IEnumerator SpawnFruits ()
	{
		yield return new WaitForSeconds(0.5f);

		while (!gameOver)
		{
			float delay = Random.Range(minDelay, maxDelay);
			int fruitIndex = Random.Range(0, fruitPrefab.Count);
			int spawnIndex = Random.Range(0, spawnPoints.Length);
			yield return new WaitForSeconds(delay);

			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(fruitPrefab[fruitIndex].fruitModel, spawnPoint.position, spawnPoint.rotation) as GameObject;

			if (PlayerPrefs.GetInt ("Sound") == 1) {
				fruitLaunchAud.clip = fruitLaunchClip;
				fruitLaunchAud.Play ();
			}

			Destroy(spawnedFruit, 10f);
		}
	}

	public void FruitSlashCheck(int fruitIndex){
		if (PlayerPrefs.GetInt ("Sound") == 1) {
			aud.clip = slashClip;
			aud.Play ();
		}
		bool correctSlash = false;
		if((fruitIndex != fruit1)&&(fruitIndex != fruit2)){
			correctSlash=true;
		}
		if (correctSlash) {
			score = score + scoreIncriment;
			scoreText.text = score.ToString ();
		} 
		else {
			Handheld.Vibrate ();
			noOfLives = noOfLives - 1;
			if(noOfLives<0){
				GameOver();
			}
			else{
				if (PlayerPrefs.GetInt ("Sound") == 1) {
					hitAud.clip = lifeReduceClip;
					hitAud.Play ();
				}
				for (int i = 0; i < (3-noOfLives); i++) {
					heartImg [i].color = Color.black;
				}
			}
			
		}
	}
		

	public void FruitFallCheck(int fruitIndex){
		bool correctLeave = true;
		if((fruitIndex != fruit1)&&(fruitIndex != fruit2)){
			correctLeave = false;
		}
		if (!correctLeave) {
			Handheld.Vibrate ();
			noOfLives = noOfLives - 1;
			if(noOfLives<0){
			GameOver();
			}
			else{
				for (int i = 0; i < (3-noOfLives); i++) {
					heartImg [i].color = Color.black;
				}
				if (PlayerPrefs.GetInt ("Sound") == 1) {
					hitAud.clip = lifeReduceClip;
					hitAud.Play ();
				}
			}
		} 
	}


	void GameOver(){
		if (!gameOver) {
			gameOver = true;
			gameOverScoreText.text = score.ToString ();
			anim.SetTrigger ("GameOver");
			if (PlayerPrefs.GetInt ("Sound") == 1) {
				aud.clip = gameOverClip;
				aud.Play ();
			}
			bkAud.volume = bkAud.volume / 2;
		}
	}

	public void Pause(){
		anim.SetTrigger ("Pause");
		StartCoroutine (Pauser ());
	}
	IEnumerator Pauser(){
		yield return new WaitForSeconds (0.1f);
		paused = true;
		Time.timeScale = 0;
	}

	public void Resume(){
		Time.timeScale = 1;
		paused = false;
		anim.SetTrigger ("Resume");
	}
		
	public void StartBtn(){
		appController.UIAudio ();
		Handheld.Vibrate ();
		anim.SetTrigger ("GameStart");
		StartCoroutine(SpawnFruits());
		if (PlayerPrefs.GetInt ("Music") == 1) {
			bkAud.clip = backGroundClip;
			bkAud.Play ();
		}
	}
		
	public void BackBtn(){
		Time.timeScale = 1;
		appController.UIAudio ();
		Handheld.Vibrate ();
		SimpleSceneFader.ChangeSceneWithFade ("Main Menu");
	}

	public void RestartBtn(){
		Time.timeScale = 1;
		appController.UIAudio ();
		Handheld.Vibrate ();
		SceneManager.LoadScene ("Fruit_Attack");
	}
}