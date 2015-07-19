using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	Animator anim;
	GameObject player;
	PlayerController p;
	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player");
		p = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (p.isDead) {

			if(ScoreManager.score > HighScore.highScore && LevelManager.level <= HighLevel.highLevel){
				
				PlayerPrefs.SetInt("HighScore",ScoreManager.score);
				HighScore.highScore = ScoreManager.score;
				anim.SetTrigger("NewHighScore");
			}
			
			if(LevelManager.level > HighLevel.highLevel && ScoreManager.score <= HighScore.highScore){
				
				PlayerPrefs.SetInt("HighLevel",LevelManager.level);
				HighLevel.highLevel = LevelManager.level;
				anim.SetTrigger("NewHighLevel");
			}
			
			if (LevelManager.level > HighLevel.highLevel && ScoreManager.score > HighScore.highScore) {
				
				PlayerPrefs.SetInt("HighScore",ScoreManager.score);
				HighScore.highScore = ScoreManager.score;
				PlayerPrefs.SetInt("HighLevel",LevelManager.level);
				HighLevel.highLevel = LevelManager.level;
				anim.SetTrigger("BothNew");
			}
			anim.SetTrigger ("GameOver");
		}

	}
}
