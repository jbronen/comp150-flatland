using UnityEngine;
using System.Collections;

public class ObjectAppearTrigger : MonoBehaviour {

	public GameObject keyObject;
	public GameObject appearingObject;
	public GameObject goalArea;

	public bool timed;
	public float timeLimit;
	public bool toggle;

	PickupObject solver;
	float timeLeft;
	bool timerOn;
	Collider keyCollider;
	SolvedGoal solvedGoal;
	
	void Start()
	{
		timerOn = false;
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
		solvedGoal = GetComponent<SolvedGoal> ();
	}
	
	void Update()
	{
		if (timerOn) {
			if (timeLeft == 0) {
				solvedGoal.unSolved();
				appearingObject.SetActive (false);
				resetTime();
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
			appearingObject.SetActive (true);
			solvedGoal.solved ();
			if (timed) {
				timeLeft = timeLimit;
				timerOn = true;
				InvokeRepeating("decreaseTimeRemaining", 1f, 1f);
			}
			if (other.tag != "Player") {
				if (!solver.holdingObject) {
					//other.transform.position = goalArea.transform.position;
				}
			}
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if (toggle) {
			if (other == keyCollider) {
				solvedGoal.unSolved();
				appearingObject.SetActive (false);
				resetTime ();
			}
		}
	}
}
