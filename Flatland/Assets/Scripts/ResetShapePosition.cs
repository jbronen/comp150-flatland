using UnityEngine;
using System.Collections;

public class ResetShapePosition : MonoBehaviour {

	public bool enableRespawn;
	public GameObject originalParent;

	Vector3 initialPosition;
	Quaternion initialRotation;
	Rigidbody rb;
	
	void Start () {
		initialPosition = transform.position;
		initialRotation = transform.rotation;
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	public void reset () {
		if (enableRespawn) {
			transform.parent = originalParent.transform;
			transform.position = initialPosition;
			transform.rotation = initialRotation;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}

	public Vector3 getPosition () {
		return initialPosition;
	}

}
