using UnityEngine;
using System.Collections;

public class Freezer : MonoBehaviour {

	public GameObject freezee;
	Rigidbody frozone;

	// Use this for initialization
	void Start () {
		frozone = freezee.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		frozone.freezeRotation = true;
	}
}
