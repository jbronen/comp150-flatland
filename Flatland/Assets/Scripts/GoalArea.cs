using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {
	
	Collider goalCollider;
	Collider keyCollider;
	SolvedGoal solvedGoal;
	PickupObject solver;
	Renderer keyRenderer;
	float height;
	bool shouldHold;
	bool solved;

	public GameObject keyObject;
	public float smooth;

	void Start ()
	{
		shouldHold = false;
		keyRenderer = keyObject.GetComponent<Renderer> ();
		height = keyRenderer.bounds.extents.magnitude;
		
		solver = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickupObject>();
		solved = false;
		solvedGoal = GetComponent<SolvedGoal>();
		goalCollider = GetComponent<Collider> ();
		keyCollider = keyObject.GetComponent<Collider> ();
	}

	void Update() 
	{
		if (shouldHold) {
			if (solved) {
				hold ();
			}
		}

		if (solver.pickingUp (keyObject)) {
			shouldHold = false;
		}
	}

	void hold()
	{
		keyCollider.transform.rotation = goalCollider.transform.rotation;
		keyCollider.transform.position = new Vector3 (goalCollider.transform.position.x, goalCollider.transform.position.y + (height / 3), goalCollider.transform.position.z);
	}

	public bool isSolved()
	{
		return solved;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other == keyCollider) {
			if (solver.holdingObject) {
				if (solver.carriedObject == other.gameObject) {
					solver.drop ();
				}
			}
			shouldHold = true;
			solved = true;
			solvedGoal.solved();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other == keyCollider) {
			solved = false;
			shouldHold = false;
			solvedGoal.unSolved();
		}
	}

}
