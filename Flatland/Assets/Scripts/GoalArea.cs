using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {
	
	Collider goalCollider;
	Collider keyCollider;
	SolvedGoal solvedGoal;
	PickupObject solver;
	Renderer keyRenderer;
	float height;

	public bool solved;
	public GameObject keyObject;
	public float smooth;
	public GameObject goal;

	void Start ()
	{
		keyRenderer = keyObject.GetComponent<Renderer> ();
		height = keyRenderer.bounds.extents.magnitude;
		
		solver = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickupObject>();
		solved = false;
		solvedGoal = GetComponent<SolvedGoal>();
		goalCollider = goal.GetComponent<Collider> ();
		keyCollider = keyObject.GetComponent<Collider> ();
	}

	void Update() 
	{
		if (solved) {
			hold();
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
			solved = true;
			solvedGoal.solved();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other == keyCollider) {
			solved = false;
			solvedGoal.unSolved();
		}
	}

}
