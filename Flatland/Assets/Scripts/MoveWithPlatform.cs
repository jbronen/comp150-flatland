using UnityEngine;
using System.Collections;

public class MoveWithPlatform : MonoBehaviour {

	public GameObject originalParent;

	GameObject solver;
	PickupObject pickupObject;
	Vector3 originalScale;

	void Start()
	{
		solver = GameObject.FindGameObjectWithTag ("Player");
		pickupObject = solver.GetComponent<PickupObject> ();
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject == pickupObject.carriedObject) {
			transform.parent = originalParent.transform;
		} else if (other.gameObject.tag == "Moving Platform") {
			transform.parent = other.transform;
		} else {
			transform.parent = originalParent.transform;
		}


	}	
}
