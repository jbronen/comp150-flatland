using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	private GameController gameController;
	private PickupObject solver;

	public Collider goalObject;
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
	}

	void OnTriggerEnter(Collider other) {
		if (other == goalObject) {
			if (goalObject.ToString() == "FullCube") {
				gameController.solvedCube ();
				if (!solver.holdingObject)
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
			}
			else if (goalObject.ToString() == "FullCylinder") {
				gameController.solvedCylinder ();
				if (!solver.holdingObject)
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
			}
			else if (goalObject.ToString() == "Pyramid") {
				gameController.solvedPyramid();
				if (!solver.holdingObject)
					other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
			}
			//else if (goalObject.ToString() == "Cube") {
				gameController.solvedTutorial();
			if (!solver.holdingObject)
				other.transform.position = goal.transform.position; //Vector3.Lerp (other.transform.position,goal.transform.position, Time.deltaTime * smooth);
			//}
		}
	}

}
