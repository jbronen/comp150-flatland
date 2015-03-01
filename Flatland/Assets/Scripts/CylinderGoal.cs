using UnityEngine;
using System.Collections;

public class CylinderGoal : MonoBehaviour {

	private GameController gameController;
	private PickupObject solver;
	
	public Collider goalObject;
	//public float smooth;

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



	void OnTriggerEnter(Collider other) 
	{
		if (other == goalObject) {
				gameController.solvedCylinder ();
			}
	}
}
