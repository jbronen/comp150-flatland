using UnityEngine;
using System.Collections;

public class ObjectAppearTrigger : MonoBehaviour {

	public GameObject keyObject;
	public GameObject appearingObject;
	public bool timed;
	public float timeLimit;
	public bool toggle;
	public Dimension keyDimension;
	public Orientation goalOrientation;

	float height;
	Renderer keyRenderer;
	bool solved;
	PickupObject solver;
	float timeLeft;
	bool timerOn;
	Collider keyCollider;
	Collider goalCollider;
	SolvedGoal solvedGoal;
	bool shouldHold;
	
	void Start()
	{
		shouldHold = false;
		keyRenderer = keyObject.GetComponent<Renderer> ();
		height = keyRenderer.bounds.extents.magnitude;
		solved = false;
		timerOn = false;
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
		goalCollider = GetComponent<Collider>();
		solvedGoal = GetComponent<SolvedGoal> ();
	}
	
	void Update()
	{
		if (timerOn) {
			if (timeLeft == 0) {
				solved = false;
				shouldHold = false;
				solvedGoal.unSolved();
				appearingObject.SetActive (false);
				resetTime();
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
				shouldHold = true;
			}
			appearingObject.SetActive (true);
			solvedGoal.solved ();
			solved = true;
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if (toggle) {
			if (other == keyCollider) {
				solved = false;
				shouldHold = false;
				solvedGoal.unSolved();
				appearingObject.SetActive (false);
				resetTime ();
			}
		}
	}
}
