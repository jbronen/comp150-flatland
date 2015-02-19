using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{

	public GameObject pyramid;
	public GameObject cylinder;

	public Text restartText;
	public Text puzzleCompleteText;

	private bool died;
	private bool puzzleComplete;
	private bool restart;
	private bool cylinder_solved;
	private bool pyramid_solved;


	// Use this for initialization
	void Start () 
	{
		died = false;
		puzzleComplete = false;
		restart = false;
		cylinder_solved = false;
		pyramid_solved = false;
		restartText.text = "";
		puzzleCompleteText.text = "";

	}
	
	// Update is called once per frame
	void Update () 
	{
		/* cylinder_solved =  some check_cylinder_solution() function
		 * checks if the square from cylinder is placed in the proper area in the game
		 * if it has, returns true, and therefore sets cylinder_solved to true
		 * same thing for pyramid_solved
		 */

		if (cylinder_solved && pyramid_solved) {
			puzzleComplete = true;
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

	public void PuzzleComplete ()
	{
		puzzleCompleteText.text = "Puzzle Complete!";
		puzzleComplete = true;
	}
}

