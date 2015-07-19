using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score;
//	AudioSource scoreAudio;
	
	GameObject player;
	PlayerController p;

	void Start () {
	
		
		player = GameObject.FindGameObjectWithTag ("Player");
		p = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
//		scoreAudio = GetComponent<AudioSource>();
	}
	public void OnTriggerEnter(Collider other) {

		if(other.tag == "Boundary" ) {

			Destroy(gameObject,0.1f);
			if(!p.isDead){

				ScoreManager.score ++;
			}

		} 
		if (other.tag == "Player") {
		
			p.Death();
			p.isDead = true;

		}

	}


}
