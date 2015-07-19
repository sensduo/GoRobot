using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	public float tumble;
	public float speed;
	public GameObject explosion;
	private bool a;

	GameObject player;
	PlayerController p;
//	public int scoreValue;
	// Use this for initialization
	void Start () {
	
		float s = 1 + (LevelManager.level - 1)/5f;
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
		rigidbody.velocity = transform.forward * -speed * s;

		player = GameObject.FindGameObjectWithTag ("Player");
		p = player.GetComponent<PlayerController>();

		a = false;
	}

	void Update(){

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
