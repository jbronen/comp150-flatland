using UnityEngine;
using System.Collections;

public class TutorialPuzzleComplete : MonoBehaviour {

	private GameController gameController;
	
	public GameObject door;
	public GameObject levelPortal;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
	}
	
	void Update()
	{
		if (door.activeSelf == false) {
			gameController.puzzleCompleted();
			levelPortal.SetActive(true);
		}
	}
}
