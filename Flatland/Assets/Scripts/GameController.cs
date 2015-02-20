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
	private bool square_solved;


	// Use this for initialization
	void Start () 
	{
		died = false;
		restart = false;
		square_solved = false;
		restartText.text = "";
		puzzleCompleteText.text = "";
		diedText.text = "";

	}

	public void Died ()
	{
		diedText.text = "Game Over!";
		died = true;
	}

	public void solveSquare() {
		puzzleCompleteText.text = "You solved the puzzle!";
		square_solved = true;
	}

	// Update is called once per frame
	void Update () 
	{
		// check square solved here

		if (square_solved) {
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

