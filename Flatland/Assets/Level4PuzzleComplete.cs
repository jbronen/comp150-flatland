using UnityEngine;
using System.Collections;

public class Level4PuzzleComplete : MonoBehaviour {


	private GameController gameController;

	public GameObject bridge;
	public GameObject levelPortal;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bridge.activeSelf) {
			gameController.puzzleCompleted ();
			levelPortal.SetActive(true);
		}
	}
}
