using UnityEngine;
using System.Collections;

public class ParticleRotator : MonoBehaviour {

	public GameObject Player;
	public Particle[] ParticleSystems;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		for (int i = 0; i<= ParticleSystems.Length; i++) {
			ParticleSystems[i].rotation = Player.transform.position.x;
		}
	}
}
