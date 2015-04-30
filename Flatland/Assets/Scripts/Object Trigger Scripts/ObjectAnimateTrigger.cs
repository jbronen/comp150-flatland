using UnityEngine;
using System.Collections;

public class ObjectAnimateTrigger : MonoBehaviour {

	public GameObject keyObject;
	public GameObject animatedObject;
//	public bool timed;
//	public float timeLimit;
//	public bool toggle;
	public Dimension keyDimension;
	public Orientation goalOrientation;

	float height;
	Animator objectAnimator;
	Renderer keyRenderer;
	bool solved;
	PickupObject solver;
//	float timeLeft;
	float holdTimeLeft;
	float holdLimit;
	bool holdTimerOn;
//	bool timerOn;
	Collider keyCollider;
	Collider goalCollider;
	SolvedGoal solvedGoal;
	bool shouldHold;

	void Start()
	{
		objectAnimator = animatedObject.GetComponent<Animator> ();
		holdTimerOn = false;
		holdLimit = 2f;
		holdTimeLeft = holdLimit;
		shouldHold = false;
		keyRenderer = keyObject.GetComponent<Renderer> ();
		height = keyRenderer.bounds.extents.magnitude;
		solved = false;
//		timerOn = false;
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
		goalCollider = GetComponent<Collider>();
		solvedGoal = GetComponent<SolvedGoal> ();

	}

	void Update()
	{
//		if (timerOn) {
//			if (timeLeft == 0) {
//				solved = false;
//				shouldHold = false;
//				solvedGoal.unSolved();
//				appearingObject.SetActive (false);
//				resetTime();
//			}
//		}
		
		if (holdTimerOn) {
			if (holdTimeLeft > 0) {
				shouldHold = false;
			} else {
				holdTimerOn = false;
			}
		}
		
		if (shouldHold) {
			if (solved) {
				hold ();
			}
		}
		
		if (solver.pickingUp (keyObject)) {
			shouldHold = false;
		}
	}
	
	void hold()
	{
		keyCollider.transform.rotation = goalCollider.transform.rotation;
		if (keyDimension == Dimension.key3D) {
			keyCollider.transform.position = new Vector3 (goalCollider.transform.position.x, goalCollider.transform.position.y + (height / 3), goalCollider.transform.position.z);
		} else {
			keyCollider.transform.position = new Vector3 (goalCollider.transform.position.x, goalCollider.transform.position.y + (height / 100), goalCollider.transform.position.z);
		}
	}
	
	public bool isSolved()
	{
		return solved;
	}
	
//	void resetTime()
//	{
//		timerOn = false;
//		timeLeft = timeLimit;
//	}
	
	void decreaseTimeRemaining()
	{
		if (holdTimerOn) {
			holdTimeLeft--;
		}
//		if (timerOn) {
//			timeLeft--;
//		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (!holdTimerOn) {
			if (other == keyCollider) {
//				if (timed) {
//					timeLeft = timeLimit;
//					timerOn = true;
//					InvokeRepeating ("decreaseTimeRemaining", 1f, .7f);
//				}
				if (other.tag != "Player") {
					if (solver.holdingObject) {
						if (solver.carriedObject == other.gameObject) {
							solver.drop ();
						}
					}
					shouldHold = true;
				}
//				appearingObject.SetActive (true);
				if (gameObject.name == "DoorTrigger1") {
					objectAnimator.Play ("buttonPressed1");
				} else if (gameObject.name == "DoorTrigger2") {
					objectAnimator.Play ("buttonPressed2");
				} else if (gameObject.name == "DoorTrigger3") {
					objectAnimator.Play ("buttonPressed3");
				} else if (gameObject.name == "DoorTrigger4") {
					objectAnimator.Play ("buttonPressed4");
				} else if (gameObject.name == "Stair Button") {
					objectAnimator.Play ("stairButtonPressed");
				}
				solvedGoal.solved ();
				solved = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (!holdTimerOn) {
			if (other == keyCollider) {
				
				holdTimeLeft = holdLimit;
				holdTimerOn = true;
				
				InvokeRepeating ("decreaseTimeRemaining", 1f, 1f);
//				if (toggle) {
//					solved = false;
//					shouldHold = false;
//					solvedGoal.unSolved ();
//					appearingObject.SetActive (false);
//					resetTime ();
//				}
			}
		}
	}
}
