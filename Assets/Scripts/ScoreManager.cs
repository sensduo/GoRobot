using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;
	
	Text text;
	// Use this for initialization
	void Start () {
	
		// Set up the reference.
		text = GetComponent <Text> ();
		
		// Reset the score.
		score = 0;



		
	}
	
	// Update is called once per frame
	void Update () {
			
		text.text = "Score: " + score;

	}


}
