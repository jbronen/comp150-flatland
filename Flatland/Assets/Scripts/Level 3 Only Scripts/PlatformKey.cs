using UnityEngine;
using System.Collections;

public class PlatformKey : MonoBehaviour {

	private GameController gameController;
	public GameObject keyObject;
	public GameObject platform;
	MovingPlatform platformMover;
	
	Collider keyCollider;

	SolvedGoal solvedGoal;
	
	void Start()
	{
//		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
//		if (gameControllerObject != null) {
//			gameController = gameControllerObject.GetComponent <GameController> ();
//		}
		keyCollider = keyObject.GetComponent<BoxCollider> ();
		platformMover = platform.GetComponent<MovingPlatform> ();
		solvedGoal = gameObject.GetComponent<SolvedGoal> ();
	}
	
	void OnTriggerStay(Collider other) 
	{
		if (other == keyCollider) {
			platformMover.move (true);
			solvedGoal.solved ();
		} else if (keyCollider.ToString().Length != other.ToString().Length) {
			platformMover.move (false);
			solvedGoal.unSolved();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other != keyCollider) {
			platformMover.move (false);
			solvedGoal.unSolved();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other == keyCollider) {
			platformMover.move (false);
			solvedGoal.unSolved();
		}
	}
}
