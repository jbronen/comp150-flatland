using UnityEngine;
using System.Collections;

public class MoveWithPlatform : MonoBehaviour {

	public GameObject originalParent;

//	Transform P;
//	Vector3 offset;
//	Vector3 newPos;
//	bool hold;
	Transform oldPos;

	GameObject solver;
	PickupObject pickupObject;
	Transform newParent;
	public Vector3 originalScale;

	void Start()
	{
		oldPos = gameObject.transform;
//		hold = false;
		solver = GameObject.FindGameObjectWithTag ("Player");
		pickupObject = solver.GetComponent<PickupObject> ();
	}

	void OnCollisionEnter(Collision other)
	{
		oldPos.rotation = gameObject.transform.rotation;
//		if (gameObject == pickupObject.carriedObject) {
//			hold = false;
//			//do nothing
//		} else if (other.gameObject.tag == "Moving Platform") {
//			P = other.transform;
//			hold = true;
////			offset = (transform.position - P.position);
////			transform.position = P.position + P.TransformDirection(offset);
//		} else {
//			hold = false;
//		}


		if (other.gameObject == pickupObject.carriedObject) {
			//transform.parent = originalParent.transform;
		} else if (other.gameObject.tag == "Moving Platform") {
			newParent = other.transform.FindChild("PlatformChild");
			if (newParent.name == "PlatformChild") {
				transform.parent = newParent;
				transform.rotation = oldPos.rotation;
				transform.localScale = originalScale;
			}
		} else if ((other.gameObject.tag == "Pickup")) {
			//transform.parent = originalParent.transform;
		}


	}	

	void FixedUpdate()
	{
		transform.localScale = originalScale;
		//Debug.Log (gameObject.name);
		if (gameObject.name == "SphereCir1") {
			Debug.Log (originalScale);
			Debug.Log (transform.localScale);
		}
	}
//		if (hold == true) {
//			offset = (transform.position);
//			newPos = new Vector3 ((P.position.x + (P.position.x - offset.x)), offset.y, (P.position.z + (P.position.z - offset.z)));
//			//P = other.transform;
//
//			//transform.position = P.position + P.TransformDirection (offset);
//			transform.position = Vector3.Lerp (offset, newPos, Time.deltaTime * 10);
//		}
//	}
}
