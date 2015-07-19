using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static int level;

	Text text;

	// Use this for initialization
	void Start () {
	
		text = GetComponent<Text> ();

		level = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
		text.text = "Level " + level;
	}
}
