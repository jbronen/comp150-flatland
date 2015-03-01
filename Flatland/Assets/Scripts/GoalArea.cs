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
<<<<<<< HEAD
=======
		//Debug.Log (goalObject.ToString ());
		/*if (goalObject.ToString () == "Cube (UnityEngine.GameObject)") {
			//Debug.Log ("It should work.");
		} else {
			//Debug.Log ("fuck if I know.");
		}*/
>>>>>>> origin/master
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
<<<<<<< HEAD
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
=======
		//goalCollider = goalObject.GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter(Collider other) {
		/*Debug.Log (other.ToString ());
		Debug.Log (goalCollider.ToString ());*/
		Debug.Log ("We are here and it's " + other.ToString ());
		if (other == goalObject) {
			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)") {
>>>>>>> origin/master
				gameController.solvedCube ();
				Debug.Log ("SOLVED CUBE");
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position;
					//other.transform.position.z = goal.transform.position.z;
				}
			}
<<<<<<< HEAD
			else if (goalObject.ToString() == "FullCylinder (UnityEngine.GameObject)") {
=======
		else if (other.ToString() == "FullCylinder (UnityEngine.GameObject)") {
>>>>>>> origin/master
				gameController.solvedCylinder ();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position;
				}
			}
<<<<<<< HEAD
			else if (goalObject.ToString() == "Pyramid (UnityEngine.GameObject)") {
=======
		else if (other.ToString() == "Pyramid (UnityEngine.MeshCollider)") {
>>>>>>> origin/master
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
