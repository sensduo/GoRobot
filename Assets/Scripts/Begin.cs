using UnityEngine;
using System.Collections;

public class Begin : MonoBehaviour {

	public GameObject gameController;
	Animator anim1;
	Animator anim2;
	Animator anim3;
	AudioSource bgm1;
	AudioSource bgm2;
	GameObject ui;
	GameObject robot;

	GameController gc;
	bool isPlaying;
	int highScore;
	// Use this for initialization
	void Start () {
	
		if(!PlayerPrefs.HasKey("HighScore")){
			PlayerPrefs.SetInt("HighScore",0);
		}
		if(!PlayerPrefs.HasKey("HighLevel")){
			PlayerPrefs.SetInt("HighLevel",0);
		}
		isPlaying = false;
		bgm2 = gameController.GetComponent<AudioSource>();
		gc = gameController.GetComponent<GameController> ();
		bgm1 = GetComponent<AudioSource>();
		anim1 = GetComponent<Animator>();
		ui = GameObject.FindWithTag("UI");
		anim2 = ui.GetComponent<Animator> ();
		robot = GameObject.FindWithTag("Robot");
		anim3 = robot.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire1")) {
			
			anim2.SetTrigger("Play");
			anim3.SetTrigger("Play");
			if(!isPlaying){
				bgm1.Stop ();
				isPlaying = true;
				anim1.SetTrigger("Play");
				gc.enabled = true;
				bgm2.Play ();
			}
		}
	}
}
