using UnityEngine;
using System.Collections;

public class Level4PuzzleComplete : MonoBehaviour {


	GameController gameController;
	ObjectAppearTrigger solutionScript;

	public GameObject solutionPlatform;
	
	void Start () {
		gameController = GameObject.FindWithTag("GameController").GetComponent <GameController> ();
		solutionScript = solutionPlatform.GetComponent<ObjectAppearTrigger> ();
	}

	void Update () 
	{
		if (solutionScript.isSolved()) {
			gameController.puzzleCompleted ();
		}
	}
}
