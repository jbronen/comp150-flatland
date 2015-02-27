using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	private GameController gameController;
	private PickupObject solver;

	public Collider goalObject;
	//Collider goalCollider;
	public float smooth;
	public Collider goal;

	void Start ()
	{
		//Debug.Log (goalObject.ToString ());
		/*if (goalObject.ToString () == "Cube (UnityEngine.GameObject)") {
			//Debug.Log ("It should work.");
		} else {
			//Debug.Log ("fuck if I know.");
		}*/
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		//goalCollider = goalObject.GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter(Collider other) {
		/*Debug.Log (other.ToString ());
		Debug.Log (goalCollider.ToString ());*/
		Debug.Log ("We are here and it's " + other.ToString ());
		if (other == goalObject) {
			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)") {
				gameController.solvedCube ();
				Debug.Log ("SOLVED CUBE");
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
				}
			}
		else if (other.ToString() == "FullCylinder (UnityEngine.GameObject)") {
				gameController.solvedCylinder ();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
				}
			}
		else if (other.ToString() == "Pyramid (UnityEngine.MeshCollider)") {
				gameController.solvedPyramid();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
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
