using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 0.1F;
	
	public GameObject robotExplosion;
	public GameObject giftExplosion;
	
	public bool isDead;
	public bool boom;
	AudioSource bgm;
	GameObject gc;
	Animator anim;

	void Start(){

		isDead = false;
		boom = false;
		anim = gameObject.GetComponent<Animator> ();
	}



	void FixedUpdate() {

		RaycastHit hit;
		Ray r;
	
		if(Input.GetMouseButton(0)){

			r = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(r,out hit,10)){
				GameObject go = hit.collider.gameObject;
				Vector3 pp = gameObject.transform.position;
				if(go.tag == "Boundary"){
					gameObject.transform.Translate((hit.point.x - pp.x) * speed, 0.0f, 0.0f);
				}
			}
		}
	}

	IEnumerator OnTriggerEnter(Collider other){

		switch (other.tag) {
		case "Hazard":
			Death();
			isDead = true;
			break;
		case "Candy":
			Destroy(other.gameObject);
			PlayerExplosion(giftExplosion);
			ScoreManager.score += 50;
			break;
		case "Present":
			Destroy(other.gameObject);
			PlayerExplosion(giftExplosion);
			ScoreManager.score += 100;
			break;
		case "TeddyBear":
			Destroy(other.gameObject);
			PlayerExplosion(giftExplosion);
			ScoreManager.score += 150;
			break;
		case "Ball":
			Destroy(other.gameObject);
			PlayerExplosion(giftExplosion);
			boom = true;
			yield return new WaitForSeconds(0.5f);
			boom = false;
			break;
		case "Star":
			Destroy(other.gameObject);
			anim.SetTrigger("Shield");
			PlayerExplosion(giftExplosion);
			break;
		}


	}

	public void Death(){

		PlayerExplosion (robotExplosion);
		gc = GameObject.FindGameObjectWithTag("GameController");
		bgm = gc.GetComponent<AudioSource>();
		gameObject.SetActive(false);
		isDead = true;
		bgm.Stop();
		gc.SetActive (false);
	}

	void PlayerExplosion(GameObject pe){

		Vector3 ep = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f);
		Object e = Instantiate(pe, ep, gameObject.transform.rotation);
		Destroy (e, 3f);
	}


}
