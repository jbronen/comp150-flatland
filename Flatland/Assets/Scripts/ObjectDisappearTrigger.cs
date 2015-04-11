using UnityEngine;
using System.Collections;

public class ObjectDisappearTrigger : MonoBehaviour {

	public GameObject keyObject;
	public GameObject disappearingObject;
	public GameObject goalArea;

	public bool toggle;
	public bool timed;
	public float timeLimit;
	
	PickupObject solver;
	float timeLeft;
	bool timerOn;
	Collider keyCollider;
	SolvedGoal solvedGoal;
	bool solved;
	Collider goalCollider;
	
	void Start()
	{
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
				solvedGoal.unSolved();
				disappearingObject.SetActive (true);
				resetTime();
			}
		}

		if (solved) {
			hold (keyCollider);
		}

		if (solver.pickingUp (keyObject)) {
			solved = false;
		}
	}

	public bool isSolved()
	{
		return solved;
	}

	void hold(Collider other)
	{
		other.transform.position = goalCollider.transform.position;
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
				other.transform.position = goalArea.transform.position;
				solved = true;
			}
		}	
	}

	void OnTriggerExit(Collider other)
	{
		if (toggle) {
			if (other == keyCollider) {
				solved = false;
				solvedGoal.unSolved();
				disappearingObject.SetActive (true);
				resetTime ();
			}
		}
	}

}
