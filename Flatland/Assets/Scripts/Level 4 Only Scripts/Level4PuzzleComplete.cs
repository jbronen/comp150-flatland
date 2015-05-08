using UnityEngine;
using System.Collections;

public class Level4PuzzleComplete : MonoBehaviour {


	GameController gameController;
	ObjectAppearTrigger solutionScript;
	Level4ControlScript control;

	public GameObject solutionPlatform;
	public GameObject circle1;
	public GameObject circle2;
	public GameObject circle3;
	
	void Start () {
		control = GetComponent<Level4ControlScript> ();
		gameController = GameObject.FindWithTag("GameController").GetComponent <GameController> ();
		solutionScript = solutionPlatform.GetComponent<ObjectAppearTrigger> ();
	}

	void Update () 
	{
		if (solutionScript.isSolved()) {
			circle1.SetActive(true);
			circle2.SetActive(true);
			circle3.SetActive(true);
			control.enabled = false;
			gameController.puzzleCompleted ();
		}
	}
}
