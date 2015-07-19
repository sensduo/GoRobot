using UnityEngine;
using System.Collections;

public class HazardController : MonoBehaviour {

	public float speed;
	public GameObject explosion;
	GameObject player;
	PlayerController p;

	private bool a;
	// Use this for initialization
	void Start () {
	
		float s = 1 + (LevelManager.level - 1) / 5f;
		rigidbody.velocity = transform.forward * -speed * s;

		player = GameObject.FindGameObjectWithTag ("Player");
		p = player.GetComponent<PlayerController>();

		a = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (p.boom && !a) {
			
			Destroy(gameObject);
			Object e = Instantiate(explosion, rigidbody.transform.position, rigidbody.transform.rotation);
			ScoreManager.score ++;
			Destroy(e, 1f);
		}
	}

	public void OnTriggerEnter(Collider other) {

		if(other.tag == "Boundary" ) {

			a = true;
			Destroy(gameObject,0.1f);
			if(!p.isDead){
				
				ScoreManager.score ++;
			}
			
		} 
	}
}
