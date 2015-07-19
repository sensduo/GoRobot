using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public GameObject[] asteroids;
	public GameObject[] bullets;
	public GameObject[] ships;
	public GameObject[] gifts;
	public GameObject ball;
	public Vector3 hazardSpawnValues;
	public Vector3 ballSpawnValues;
	public Vector3 giftSpawnValues;
	public int asteroidCount;
	public int bulletCount;
	public int shipCount;
	public int ballCount;
	public float asteroidSpawnWait;
	public float bulletSpawnWait;
	public float shipSpawnWait;
	public float ballSpawnWait;
	public Vector2 giftSpawnWait;
	public float startWait;
	public float waveWait;

	GameObject player;
	GameObject ui;
	PlayerController p;
	Animator anim;

	private int score;
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		p = player.GetComponent<PlayerController>();
		ui = GameObject.FindWithTag ("UI");
		anim = ui.GetComponent<Animator> ();
		StartCoroutine (SpawnWaves ());
		StartCoroutine (SpawnGifts ());
	}


	public void Spawn(GameObject[] gameObjects, Vector3 spawnValues){

		GameObject go = gameObjects [Random.Range (0, gameObjects.Length)];
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		if (!p.isDead) {
				
			Instantiate (go, spawnPosition, spawnRotation);
		}
	}


	IEnumerator SpawnWaves ()
	{

		while(true){

			anim.SetTrigger("LevelUp");

			float speed = 1 - (LevelManager.level - 1)/5f;
			float count = 1 + (LevelManager.level - 1)/5f;

			yield return new WaitForSeconds (startWait * speed);

			//Spawn asteroids
			for (int i = 0; i < asteroidCount * count; i++) {
				Spawn (asteroids, hazardSpawnValues);
				yield return new WaitForSeconds (asteroidSpawnWait * speed);
			}
			yield return new WaitForSeconds (waveWait * speed);

			//Spawn laser
			for (int i = 0; i < bulletCount * count; i++) {
				Spawn (bullets, hazardSpawnValues);
				yield return new WaitForSeconds (bulletSpawnWait * speed);
			}
			yield return new WaitForSeconds (waveWait * speed);

			//Spawn spacecraft
			for (int i = 0; i < shipCount * count; i++) {
				Spawn (ships, hazardSpawnValues);
				yield return new WaitForSeconds (shipSpawnWait * speed);
			}
			yield return new WaitForSeconds (waveWait * speed);


			//Spawn energy balls
			Vector3 ballSpawnPosition = new Vector3 (
				Random.Range (-ballSpawnValues.x, ballSpawnValues.x) - 2f, 
				ballSpawnValues.y, 
				ballSpawnValues.z
				);

			for (int i = 0; i < ballCount * count; i++) {

				Vector3 ballSpawnPosition1 = new Vector3 (
					Mathf.Clamp(Random.Range (ballSpawnPosition.x - 0.25f, ballSpawnPosition.x + 0.25f), -3f, -1f), 
					ballSpawnPosition.y, 
					ballSpawnPosition.z
					);
				Vector3 ballSpawnPosition2 = new Vector3 (ballSpawnPosition1.x + 4f, ballSpawnPosition1.y, ballSpawnPosition1.z);
				Quaternion ballSpawnRotation = Quaternion.identity;
				if (!p.isDead) {
					Instantiate (ball, ballSpawnPosition1, ballSpawnRotation);
					Instantiate (ball, ballSpawnPosition2, ballSpawnRotation);
					ballSpawnPosition = ballSpawnPosition1;
				}
				yield return new WaitForSeconds (ballSpawnWait * speed);
			}
			yield return new WaitForSeconds (waveWait * speed);

			if(!p.isDead)
				LevelManager.level++;
		}
	}

	IEnumerator SpawnGifts(){

		while (true) {
				
			yield return new WaitForSeconds(Random.Range(giftSpawnWait.x, giftSpawnWait.y));
			Spawn (gifts, giftSpawnValues);
		}
	}

}