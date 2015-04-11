﻿using UnityEngine;
using System.Collections;

public class Level2PuzzleComplete : MonoBehaviour {

	public GameObject cubeGA;
	public GameObject pyramidGA;
	public GameObject cylinderGA;
	public GameObject levelPortal;

	private GoalArea cubeGoalArea;
	private GoalArea pyramidGoalArea;
	private GoalArea cylinderGoalArea;
	private GameController gameController;

	void Start()
	{
		cubeGoalArea = cubeGA.GetComponent<GoalArea> ();
		pyramidGoalArea = pyramidGA.GetComponent<GoalArea> ();
		cylinderGoalArea = cylinderGA.GetComponent<GoalArea> ();

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
		if (cubeGoalArea.isSolved()) {
			if (pyramidGoalArea.isSolved()) {
				if (cylinderGoalArea.isSolved()) {
					levelPortal.SetActive(true);
					gameController.puzzleCompleted();
				}
			}
		}
	}
}
