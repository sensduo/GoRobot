using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimationController : MonoBehaviour {


	Animator animator;
	bool paused;

	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Paused") && !paused) {
			paused = true;
			Time.timeScale = 0;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Playing") && paused) {
			paused = false;
		}

	}
}
