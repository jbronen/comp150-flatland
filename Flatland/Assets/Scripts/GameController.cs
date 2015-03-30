using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

	public Text restartText;
	public Text puzzleCompleteText;
	public Text diedText;
//	public GameObject levelPortal;
	
	private bool died;
	private bool restart;

//	private bool cylinderSolved;
//	private bool cubeSolved;
//	private bool pyramidSolved;
	private bool puzzleComplete;

	// Use this for initialization
	void Start () 
	{
		died = false;
		restart = false;

//		cylinderSolved = false;
//		cubeSolved = false;
//		pyramidSolved = false;
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

//	public void solvedCylinder () {
//		if (cylinderSolved == false) {
//			cylinderSolved = true;
//		} else {
//			cylinderSolved = false;
//		}
//	}
//
//	public void solvedCube () {
//		if (cubeSolved == false) {
//			cubeSolved = true;
//		} else {
//			cubeSolved = false;
//		}
//	}
//
//	public void solvedPyramid () {
//		if (pyramidSolved == false) {
//			pyramidSolved = true;
//		} else {
//			pyramidSolved = false;
//		}
//	}

	// Update is called once per frame
	void Update () 
	{
		// check square solved here
//		if (cylinderSolved && cubeSolved && pyramidSolved) {
//			puzzleComplete = true;
//			levelPortal.transform.position = new Vector3 (103.6f, 12.2f, 11.1f);
//			puzzleCompleted();
//		}

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

