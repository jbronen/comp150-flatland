using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	private GameController gameController;

	public Collider goalObject;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other == goalObject) {
			if (goalObject.ToString() == "FullCube") {
				gameController.solvedCube ();
			}
			else if (goalObject.ToString() == "FullCylinder") {
				gameController.solvedCylinder ();
			}
			else if (goalObject.ToString() == "Pyramid") {
				gameController.solvedPyramid();
			}
			else if (goalObject.ToString() == "Cube") {
				gameController.solvedTutorial();
			}
		}
	}

}
