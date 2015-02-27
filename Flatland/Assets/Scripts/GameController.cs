﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

	public Text restartText;
	public Text puzzleCompleteText;
	public Text diedText;
	public GameObject levelPortal;
	
	private bool died;
	private bool restart;

	private bool cylinderSolved;
	private bool cubeSolved;
	private bool pyramidSolved;
	private bool tutorialCubeSolved;
	private bool puzzleComplete;
	/*
	public GameObject cylinder, circle, cyl_rect;
	public GameObject cube, square, square2;
	public GameObject pyramid, triang_prism, pyramid_square;

	public ShapeSwitch cylinderSwitcher = new ShapeSwitch(circle, cylinder, cyl_rect);
	public ShapeSwitch cubeSwitcher = new ShapeSwitch(square, cube, square2);
	public ShapeSwitch pyramidSwitcher = new ShapeSwitch(pyramid, pyramid_square, triang_prism);
	*/

	// Use this for initialization
	void Start () 
	{
		//levelPortal.transform.position = new Vector3 (-.5f, 16f, 18f);
		died = false;
		restart = false;

		cylinderSolved = false;
		cubeSolved = false;
		tutorialCubeSolved = false;
		pyramidSolved = false;
		puzzleComplete = false;

		restartText.text = "";
		puzzleCompleteText.text = "";
		diedText.text = "";

	}

	public bool solved () {
		return puzzleComplete;
	}

	public void Died ()
	{
		diedText.text = "Game Over!";
		died = true;
	}

	public void puzzleCompleted () 
	{
		puzzleCompleteText.text = "You solved the puzzle!";
		puzzleComplete = true;
	}

	public void solvedCylinder () {
		cylinderSolved = true;
	}

	public void solvedCube () {
		cubeSolved = true;
	}

	public void solvedTutorial() {
		tutorialCubeSolved = true;
	}

	public void solvedPyramid () {
		pyramidSolved = true;
	}

	// Update is called once per frame
	void Update () 
	{
		// check square solved here
		if (cylinderSolved && cubeSolved && pyramidSolved) {
			puzzleComplete = true;
		}

		if (tutorialCubeSolved) {
			puzzleCompleteText.text = "You solved the puzzle!";
			levelPortal.transform.position = new Vector3 (-.5f, 6f, 18f);
			puzzleComplete = true;
		}

		if (puzzleComplete) {
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}

		if (died) {
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}

		if (restart) 
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	
	}

}

