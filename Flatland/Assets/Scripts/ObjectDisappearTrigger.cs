using UnityEngine;
using System.Collections;

public enum Dimension {
	key2D, key3D
}

public enum Orientation {
	onFloor, onWall
}

public class ObjectDisappearTrigger : MonoBehaviour {

	public GameObject keyObject;
	public GameObject disappearingObject;
	public bool toggle;
	public bool timed;
	public float timeLimit;
	public Dimension keyDimesion;
	public Orientation goalOrientation;

	float height;
	Renderer keyRenderer;
	bool shouldHold;
	PickupObject solver;
	float timeLeft;
	bool timerOn;
	Collider keyCollider;
	SolvedGoal solvedGoal;
	bool solved;
	Collider goalCollider;
	
	void Start()
	{
		keyRenderer = keyObject.GetComponent<Renderer> ();
		height = keyRenderer.bounds.extents.magnitude;
		shouldHold = false;
		solved = false;
		solvedGoal = GetComponent<SolvedGoal> ();
		timerOn = false;
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
		goalCollider = GetComponent<Collider> ();
	}
	
	void Update()
	{
		if (timerOn) {
			if (timeLeft == 0) {
				solved = false;
				shouldHold = false;
				solvedGoal.unSolved();
				disappearingObject.SetActive (true);
				resetTime();
			}
		}

		if (shouldHold) {
			if (solved) {
				hold (keyCollider);
			}
		}

		if (solver.pickingUp (keyObject)) {
			shouldHold = false;
		}
	}

	public bool isSolved()
	{
		return solved;
	}

	void hold(Collider other)
	{
		keyCollider.transform.rotation = goalCollider.transform.rotation;
		if (goalOrientation == Orientation.onFloor) {
			if (keyDimesion == Dimension.key2D) {
				keyCollider.transform.position = new Vector3 (goalCollider.transform.position.x, goalCollider.transform.position.y + (height / 100), goalCollider.transform.position.z);
			} else {
				keyCollider.transform.position = new Vector3 (goalCollider.transform.position.x, goalCollider.transform.position.y + (height / 3), goalCollider.transform.position.z);
			}
		} else {
			if (keyDimesion == Dimension.key2D) {
				keyCollider.transform.position = new Vector3 (goalCollider.transform.position.x, goalCollider.transform.position.y + (height / 100), goalCollider.transform.position.z);
			} else {
				keyCollider.transform.position = new Vector3 (goalCollider.transform.position.x, goalCollider.transform.position.y + (height / 3), goalCollider.transform.position.z);
			}
		}
	}
	
	void resetTime()
	{
		timerOn = false;
		timeLeft = timeLimit;
	}
	
	void decreaseTimeRemaining()
	{
		timeLeft--;
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other == keyCollider) {
			solvedGoal.solved ();
			disappearingObject.SetActive (false);
			if (timed) {
				timeLeft = timeLimit;
				timerOn = true;
				InvokeRepeating("decreaseTimeRemaining", 1f, 1f);
			}
			if (other.tag != "Player") {
				if (solver.holdingObject) {
					if (solver.carriedObject == other.gameObject) {
						solver.drop ();
					}
				}
				solved = true;
				shouldHold = true;
			}
		}	
	}

	void OnTriggerExit(Collider other)
	{
		if (toggle) {
			if (other == keyCollider) {
				solved = false;
				shouldHold = false;
				solvedGoal.unSolved();
				disappearingObject.SetActive (true);
				resetTime ();
			}
		}
	}

}
