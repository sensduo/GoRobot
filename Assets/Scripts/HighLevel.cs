using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighLevel : MonoBehaviour {

	public static int highLevel;
	Text text;
	// Use this for initialization
	void Start () {
		
		text = GetComponent <Text> ();
		highLevel = PlayerPrefs.GetInt("HighLevel");
	}
	
	// Update is called once per frame
	void Update () {
		

		text.text = "High Level: " + highLevel;
	}
}