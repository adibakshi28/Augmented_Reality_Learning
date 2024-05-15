using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FactController : MonoBehaviour {

	public bool animated;
	public float speed=0.03f;
	public Text textContainer;
	public string[] facts;


	void Start () {
		if (!animated) {
			textContainer.text = "Did you know : " + facts [Random.Range (0, facts.Length)];
		}
		else{
			StartCoroutine (WordAppear (facts[Random.Range(0,facts.Length)]));
		}
	}

	IEnumerator WordAppear(string fact){
		textContainer.text = "Did you know : ";
		for (int i = 0; i < fact.Length; i++) {
			textContainer.text = textContainer.text + fact [i];
			yield return new WaitForSeconds (speed);
		}
	}


}
