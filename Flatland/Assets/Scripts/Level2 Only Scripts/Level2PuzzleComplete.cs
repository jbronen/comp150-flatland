using UnityEngine;
using System.Collections;

public class Level2PuzzleComplete : MonoBehaviour {

	private GameController gameController;

	public GameObject step1;
	public GameObject step2;
	public GameObject step3;

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
		if (step1.activeSelf == true) {
			if (step2.activeSelf == true) {
				if (step3.activeSelf == true) {
					gameController.puzzleCompleted();
				}
			}
		}
	}


}
