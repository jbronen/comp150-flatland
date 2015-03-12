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
		keyCollider = keyObject.GetComponent<BoxCollider> ();
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other == keyCollider) {
			if (step.activeSelf == false) {
				step.SetActive (true);
			}
			if (!solver.holdingObject) {
				//other.transform.position = new Vector3 (keyObject.transform.position.x, keyObject.transform.position.y + .1f, keyObject.transform.position.z);
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
