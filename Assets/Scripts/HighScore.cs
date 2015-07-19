using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public static int highScore;

	Text text;
	// Use this for initialization
	void Start () {
	
		text = GetComponent <Text> ();
		highScore = PlayerPrefs.GetInt("HighScore");

	}
	
	// Update is called once per frame
	void Update () {


		text.text = "High Score: " + highScore;
	}
}
