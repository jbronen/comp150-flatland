using UnityEngine;
using System.Collections;

public class ResetShapePosition : MonoBehaviour {


	public Vector3 initialPosition;
	public Quaternion initialRotation;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		initialRotation = transform.rotation;
	}

	public void reset () {
		transform.position = initialPosition;
		transform.rotation = initialRotation;
	}

}
