using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour {

	public void Resume(){
		


		GameObject ui = GameObject.FindWithTag("UI");
		Animator anim = ui.GetComponent<Animator> ();
		anim.SetTrigger ("CountDown");
		StartCoroutine (GetReady ());
		anim.SetTrigger ("Resume");


	}

	IEnumerator GetReady(){

		GameObject ctext = GameObject.FindWithTag("CountDownText");
		Text text = ctext.GetComponent<Text>();

		text.enabled = true;

		text.text = "3";
		yield return StartCoroutine (WaitForRealSeconds (1f));

		text.text = "2";
		yield return StartCoroutine (WaitForRealSeconds (1f));

		text.text = "1";
		yield return StartCoroutine (WaitForRealSeconds (1f));

		text.enabled = false;

		Time.timeScale = 1;

		GameObject gc = GameObject.FindWithTag("GameController");
		AudioSource audio = gc.GetComponent<AudioSource>();
		audio.Play ();
	}

	Color changeAlpha(Color color, float newAlpha){

		color.a = newAlpha;
		return color;
	}

	IEnumerator WaitForRealSeconds(float t){

		float endt = Time.realtimeSinceStartup + t;

		while (Time.realtimeSinceStartup < endt) {
				
			yield return null;
		}
	}
}
