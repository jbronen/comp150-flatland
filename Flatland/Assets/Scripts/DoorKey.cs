using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour {

	private GameController gameController;
	public GameObject keyObject;
	public GameObject door;

	Collider keyCollider;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		keyCollider = keyObject.GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other == keyCollider) {
			door.SetActive (false);
			gameController.puzzleCompleted();
		}
	}
}
