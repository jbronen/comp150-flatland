using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialIntro : MonoBehaviour {

	public Camera cinematicCamera;
	public Camera mainCamera;
	public Canvas welcomeUI;
	public GameObject tutorialParent;
	public GameObject goalArea;
	public GameObject button;
	public GameObject shape;

	GameController gameController;
	bool startTutorial;
	int tutorialLevel;
	GameObject instructions;
	Text currInstruction;
	GameObject solver;
	PickupObject pickupObject;
	ObjectAppearTrigger goalScript;
	ObjectAppearTrigger buttonScript;
	
	bool pressedA;
	bool pressedS;
	bool pressedW;
	bool pressedD;

	void Start () 
	{
		solver = GameObject.FindGameObjectWithTag ("Player");
		pickupObject = solver.GetComponent<PickupObject> ();
		gameController = GetComponent <GameController> ();
		
		goalScript = goalArea.GetComponent<ObjectAppearTrigger> ();
		buttonScript = button.GetComponent<ObjectAppearTrigger> ();

		tutorialLevel = 0;
		startTutorial = false;

		//Time.timeScale = 0;

		mainCamera.enabled = false;
		cinematicCamera.enabled = true;

		pressedA = false;
		pressedD = false;
		pressedS = false;
		pressedW = false;
	}

	void Update()
	{
		if (!startTutorial) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				welcomeUI.enabled = false;
				startTutorial = true;
				tutorialLevel = 1;
				Time.timeScale = 1;
				mainCamera.enabled = true;
				cinematicCamera.enabled = false;
			}
		}

		if (startTutorial) {
			runTutorial();
		}
	}

	void runTutorial()
	{
		instructions = GameObject.Find("Tutorial 1");
		currInstruction = instructions.GetComponentInChildren<Text>();

		if (tutorialLevel == 1) {
			moveTutorial (currInstruction);
		} else if (tutorialLevel == 2) {
			jumpTutorial (currInstruction);
		} else if (tutorialLevel == 3) {
			pickupTutorial (currInstruction);
		} else if (tutorialLevel == 4) {
			changeTutorial (currInstruction);
		} else if (tutorialLevel == 5) {
			rotateTutorial (currInstruction);
		} else if (tutorialLevel == 6) {
			dropTutorial (currInstruction);
		} else if (tutorialLevel == 7) {
			buttonTutorial (currInstruction);
		} else if (tutorialLevel == 8) {
			matchTutorial (currInstruction);
		} else if (tutorialLevel == 9) {
			portalTutorial (currInstruction);
		}
	}

	void moveTutorial(Text instr)
	{
		//teach about moving
		instr.text = "Move with aswd";
		
		if (Input.GetKeyDown (KeyCode.A)) {
			pressedA = true;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			pressedS = true;
		} else if (Input.GetKeyDown (KeyCode.W)) {
			pressedW = true;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			pressedD = true;
		}
		
		if ((pressedA) && (pressedS) && (pressedW) && (pressedD)) {
			tutorialLevel = 2;
		}
	}

	void jumpTutorial(Text instr)
	{
		//teach about jumping
		instr.text = "Jump with Space";

		if (Input.GetKeyDown (KeyCode.Space)) {
			tutorialLevel = 3;
		}
	}

	void pickupTutorial(Text instr)
	{
		shape.SetActive (true);
		//teach about picking up objects
		instr.text = "red objects can be picked up with Left Click";

		if (pickupObject.holdingObject) {
			tutorialLevel = 4;
		}
	}

	void changeTutorial(Text instr)
	{
		//teach about changing objects
		instr.text = "Change Object with Right Click";

		if (pickupObject.holdingObject) {
			if (Input.GetMouseButtonDown (1)) {
				tutorialLevel = 5;
			}
		}
	}

	void rotateTutorial(Text instr)
	{
		//teach about rotating objects
		instr.text = "Rotate Object with arrow keys";

		if (pickupObject.holdingObject) {
			if ((Input.GetKeyDown (KeyCode.LeftArrow)) || (Input.GetKeyDown (KeyCode.RightArrow)) || (Input.GetKeyDown (KeyCode.UpArrow)) || (Input.GetKeyDown (KeyCode.DownArrow))) {
				tutorialLevel = 6;
			}
		}
	}

	void dropTutorial(Text instr)
	{
		//teach about dropping objects
		instr.text = "Drop object with left click";

		if (Input.GetMouseButtonDown (0)) {
			if (!pickupObject.holdingObject) {
				tutorialLevel = 7;
			}
		}
	}

	void buttonTutorial(Text instr)
	{
		button.SetActive (true);
		//teach about buttons
		instr.text = "Purple shapes are buttons - jump on them - green means solved";

		if (buttonScript.isSolved()) {
			tutorialLevel = 8;
		}
	}

	void matchTutorial(Text instr)
	{
		//goalArea.SetActive (true);
		//teach about matching objects to solutions
		instr.text = "yellow shapes are switches - match the red shape to the yellow shape";

		if (goalScript.isSolved ()) {
			tutorialLevel = 9;
		}
	}

	void portalTutorial(Text instr)
	{
		//teach about level portals
		instr.text = "walk into green light to continue to the next level";

		gameController.tutorialComplete ();
	}
}
