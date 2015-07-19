using UnityEngine;
using System.Collections;

public class GiftController : MonoBehaviour {
	
	public float tumble;
	public float speed;

	// Use this for initialization
	void Start () {
	
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
		rigidbody.velocity = transform.forward * -speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other) {
		
		if(other.tag == "Boundary" ) {
			
			Destroy(gameObject,0.2f);

		} 
	}
}
