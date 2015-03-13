using UnityEngine;
using System.Collections;

public class DeathByPit : MonoBehaviour {

	private GameController gameController;
	private ResetShapePosition reset;
	
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
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			gameController.Died ();
		}
		if (other.tag == "Pickup") {
			reset = other.GetComponentInParent<ResetShapePosition>();
			reset.reset ();
		}
	}
}
