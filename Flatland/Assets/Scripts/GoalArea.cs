using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {
	
	Collider goalCollider;
	SolvedGoal solvedGoal;

	public bool solved = false;
	public GameObject goalObject;
	public float smooth;
	public GameObject goal;

	void Start ()
	{
		solvedGoal = GetComponent<SolvedGoal>();
		if (goalObject.ToString () == "FullCylinder (UnityEngine.GameObject)") {
			goalCollider = goalObject.GetComponent<MeshCollider> ();
		} else if (goalObject.ToString () == "Pyramid (UnityEngine.GameObject)") {
			goalCollider = goalObject.GetComponent<MeshCollider> ();
		} else {
			goalCollider = goalObject.GetComponent<BoxCollider> ();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other == goalCollider) {
			solved = true;
			solvedGoal.solved();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other == goalCollider) {
			solved = false;
			solvedGoal.unSolved();
		}
	}

}
