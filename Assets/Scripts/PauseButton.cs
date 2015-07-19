using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	public void Pause(){

		GameObject ui = GameObject.FindGameObjectWithTag("UI");
		Animator anim = ui.GetComponent<Animator> ();	
		anim.SetTrigger ("Pause");

	}

}
