using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	private GameController gameController;
	private PickupObject solver;

	public GameObject goalObject;
	Collider goalCollider;
	public float smooth;
	public GameObject goal;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		if (goalObject.ToString () == "FullCylinder (UnityEngine.GameObject)") {
			goalCollider = goalObject.GetComponent<CapsuleCollider> ();
			Debug.Log (goalCollider.ToString());
		} else if (goalObject.ToString () == "Pyramid (UnityEngine.GameObject)") {
			goalCollider = goalObject.GetComponent<MeshCollider> ();
		}
		else {
			goalCollider = goalObject.GetComponent<BoxCollider> ();
		}
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.ToString ());
		//Debug.Log (goalCollider.ToString ());
		if (other.ToString() == goalCollider.ToString()) {
			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)" || goalObject.ToString() == "CubeSquare2 (UnityEngine.GameObject)") {
				gameController.solvedCube ();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position;
					//other.transform.position.z = goal.transform.position.z;
				}
			}
			else if (goalObject.ToString() == "FullCylinder (UnityEngine.GameObject)") {
				gameController.solvedCylinder ();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position;
				}
			}
			else if (goalObject.ToString() == "Pyramid (UnityEngine.GameObject)") {
				gameController.solvedPyramid();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position;
				}
			}
			else if (goalObject.ToString() == "Cube (UnityEngine.GameObject)") {
				gameController.solvedTutorial();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
				}
			}
		}
	}

}
