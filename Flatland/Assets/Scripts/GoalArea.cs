using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	private GameController gameController;
	private PickupObject solver;

	//public GameObject tutorialWall;
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
		Debug.Log (goalObject.ToString());
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

	/*void OnTriggerEnter(Collider other) {
		//Debug.Log (other.ToString ());
		//Debug.Log (goalCollider.ToString ());
		if (other.ToString() == goalCollider.ToString()) {
			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)" || goalObject.ToString() == "CubeSquare2 (UnityEngine.GameObject)") {
		goalCollider = goalObject.GetComponent<BoxCollider> ();
			}
		}
	}*/

	void OnTriggerEnter(Collider other) {
		/*Debug.Log (other.ToString ());
		Debug.Log (goalCollider.ToString ());*/
		//Debug.Log ("We are here and it's " + other.ToString ());
		//Debug.Log (goalCollider.ToString ());
		if (other == goalCollider) {
			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)") {
				gameController.solvedCube ();
				//Debug.Log ("SOLVED CUBE");
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position;
					//other.transform.position.z = goal.transform.position.z;
				}
			}
			else if (goalObject.ToString() == "FullCylinder (UnityEngine.GameObject)") {
				//Debug.Log ("SOLVED CYL");
				gameController.solvedCylinder ();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position;
				}
			}
			else if (goalObject.ToString() == "Pyramid (UnityEngine.GameObject)") {
				gameController.solvedPyramid();
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position + new Vector3(0,1,0);
				}
			}
			else if (goalObject.ToString() == "Cube (UnityEngine.GameObject)") {
				gameController.solvedTutorial();
				//tutorialWall.SetActive (false);
				if (!solver.holdingObject) {
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other == goalCollider) {
			if (goalObject.ToString() == "FullCube (UnityEngine.GameObject)") {
				//turn off solved cube
				gameController.solvedCube();
			}
			else if (goalObject.ToString() == "FullCylinder (UnityEngine.GameObject)") {
				//turn off solved cylinder
				gameController.solvedCylinder();
			}
			else if (goalObject.ToString() == "Pyramid (UnityEngine.GameObject)") {
				//turn off solved pyramid
				gameController.solvedPyramid();
			}
		}
	}

}
