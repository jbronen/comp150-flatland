using UnityEngine;
using System.Collections;

public class NoMagic : MonoBehaviour {

	public GameObject shape;
	//BoxCollider col;
	SphereCollider playerCol;
	//Camera mainCamera;
	public bool freeze;
	//PickupObject pickupObject;

	// Use this for initialization
	void Start () {
		playerCol = GameObject.FindWithTag ("Player").GetComponent<SphereCollider> ();
		Debug.Log (playerCol.ToString ());
		//mainCamera = GameObject.FindWithTag ("Player").GetComponent<Camera> ();
		//col = shape.GetComponent<BoxCollider> ();
		freeze = false;
		//pickupObject = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.ToString ());
		if (other == playerCol) {
			//pickupObject.freeze = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other == playerCol) {
			//pickupObject.freeze = false;
		}
	}
}
