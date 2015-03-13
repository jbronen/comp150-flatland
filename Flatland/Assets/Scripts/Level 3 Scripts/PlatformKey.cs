using UnityEngine;
using System.Collections;

public class PlatformKey : MonoBehaviour {

	private GameController gameController;
	public GameObject keyObject;
	public GameObject platform;
	MovingPlatform platformMover;
	
	Collider keyCollider;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		keyCollider = keyObject.GetComponent<BoxCollider> ();
		platformMover = platform.GetComponent<MovingPlatform> ();
	}
	
	void OnTriggerStay(Collider other) 
	{
		if (other == keyCollider) {
			platformMover.move (true);
		} else if (keyCollider.ToString().Length != other.ToString().Length) {
			platformMover.move (false);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other != keyCollider) {
			platformMover.move (false);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other == keyCollider) {
			platformMover.move (false);
		}
	}
}
