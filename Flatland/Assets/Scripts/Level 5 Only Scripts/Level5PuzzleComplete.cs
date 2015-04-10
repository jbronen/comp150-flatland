using UnityEngine;
using System.Collections;

public class Level5PuzzleComplete : MonoBehaviour {

	public GameObject leftGoal;
	public GameObject rightGoal;
	public GameObject levelPortal;

	ObjectAppearTrigger leftGoalArea;
	ObjectDisappearTrigger rightGoalArea;
	GameController gameController;
	GameObject gameControllerObject;

	void Start()
	{
		leftGoalArea = leftGoal.GetComponent<ObjectAppearTrigger> ();
		rightGoalArea = rightGoal.GetComponent<ObjectDisappearTrigger> ();
		gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();
	}
	
	void Update()
	{
		if (leftGoalArea.isSolved()) {
			if (rightGoalArea.isSolved()) {
				levelPortal.SetActive(true);
				gameController.puzzleCompleted();
			}
		}
	}
}
