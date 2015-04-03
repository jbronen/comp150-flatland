using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

//	private GameController gameController;
//	private PickupObject solver;
	Collider goalCollider;
	SolvedGoal solvedGoal;

	public bool solved = false;
	public GameObject goalObject;
	public float smooth;
	public GameObject goal;

	void Start ()
	{
		solvedGoal = GetComponent<SolvedGoal>();
//		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
//		if (gameControllerObject != null) {
//			gameController = gameControllerObject.GetComponent <GameController> ();
//		}
//		if (gameController == null) {
//			Debug.Log ("Cannot find 'GameController' script");
//		}
//		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		if (goalObject.ToString () == "FullCylinder (UnityEngine.GameObject)") {
			goalCollider = goalObject.GetComponent<MeshCollider> ();
			Debug.Log (goalCollider.ToString());
		} else if (goalObject.ToString () == "Pyramid (UnityEngine.GameObject)") {
			goalCollider = goalObject.GetComponent<MeshCollider> ();
		}
		else {
			goalCollider = goalObject.GetComponent<BoxCollider> ();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other == goalCollider) {
			solved = true;
			solvedGoal.solved();
//			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)") {
//				gameController.solvedCube ();
//				//Debug.Log ("SOLVED CUBE");
//				if (!solver.holdingObject) {
//					other.transform.position = goal.transform.position;
//					//other.transform.position.z = goal.transform.position.z;
//				}
//			}
//			else if (goalObject.ToString() == "FullCylinder (UnityEngine.GameObject)") {
//				//Debug.Log ("SOLVED CYL");
//				gameController.solvedCylinder ();
//				if (!solver.holdingObject) {
//					other.transform.position = goal.transform.position;
//				}
//			}
//			else if (goalObject.ToString() == "Pyramid (UnityEngine.GameObject)") {
//				gameController.solvedPyramid();
//				if (!solver.holdingObject) {
//					other.transform.position = goal.transform.position + new Vector3(0,1,0);
//				}
//			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other == goalCollider) {
			solved = false;
//			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)") {
//				//turn off solved cube
//				gameController.solvedCube();
//			}
//			else if (goalObject.ToString() == "FullCylinder (UnityEngine.GameObject)") {
//				//turn off solved cylinder
//				gameController.solvedCylinder();
//			}
//			else if (goalObject.ToString() == "Pyramid (UnityEngine.GameObject)") {
//				//turn off solved pyramid
//				gameController.solvedPyramid();
//			}
		}
	}

}
