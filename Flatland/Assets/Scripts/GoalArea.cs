using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	private GameController gameController;

	public Collider goalCube;

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
		if (other == goalCube) {
			gameController.solveSquare ();
		}
	}

}
