using UnityEngine;
using System.Collections;

public class StepKey : MonoBehaviour {

	public GameObject keyObject;
	public GameObject step;
	
	private PickupObject solver;
	Collider keyCollider;
	
	void Start()
	{
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other == keyCollider) {
			if (step.activeSelf == false) {
				step.SetActive (true);
			}
		}
		if (other.tag == "Pickup") {
			if (!solver.holdingObject) {
				other.transform.position = keyObject.transform.position;
			}
		}
		
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other == keyCollider) {
			step.SetActive (false);
		}
	}
}
