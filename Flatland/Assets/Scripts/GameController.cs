using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

	public Text restartText;
	public Text puzzleCompleteText;
	public Text diedText;
	
	private bool died;
	private bool restart;
	private bool puzzleComplete;
	
	void Start () 
	{
		died = false;
		restart = false;
		puzzleComplete = false;

		restartText.text = "";
		puzzleCompleteText.text = "";
		diedText.text = "";

	}

	public bool solved () 
	{
		return puzzleComplete;
	}

	public void Died ()
	{
		diedText.text = "Game Over!";
		died = true;
	}

	public void tutorialComplete()
	{
		puzzleComplete = true;
	}

	public void puzzleCompleted () 
	{
		puzzleCompleteText.text = "You solved the puzzle!";
		puzzleComplete = true;
	}
	
	void Update () 
	{
		if (died) {
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}

		if (restart) 
		{
			if (Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

}

