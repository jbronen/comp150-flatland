using UnityEngine;
using System.Collections;

public class TutorialPuzzleComplete : MonoBehaviour {

	private GameController gameController;
	
	public GameObject door;
	
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
	
	void Update()
	{
		if (door.activeSelf == false) {
			gameController.puzzleCompleted();
		}
	}
}
