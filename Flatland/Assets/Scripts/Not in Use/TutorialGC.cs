using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialGC : MonoBehaviour {

	public Text restartText;
	public Text puzzleCompleteText;
	public Text diedText;

	private bool cubeSolved;
	private bool puzzleComplete;
	private bool died;
	private bool restart;
	
	void Start () 
	{
		died = false;
		restart = false;

		cubeSolved = false;
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

	public void puzzleCompleted () {
		puzzleCompleteText.text = "You solved the puzzle!";
		puzzleComplete = true;
	}

	public void solvedTutorial() {
		cubeSolved = true;
	}

	void Update () 
	{
		// check square solved here
		if (cubeSolved) {
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
