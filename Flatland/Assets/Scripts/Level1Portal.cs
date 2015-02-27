using UnityEngine;
using System.Collections;

public class Level1Portal : MonoBehaviour {

	private GameController gameController;
	
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

	void OnTriggerEnter(Collider other)
	{
		if (gameController.solved()) {
			if (other.transform.tag == "Player") {
				Application.LoadLevel ("Level1");
			}
		}
	}
}
