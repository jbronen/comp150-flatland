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
	
	void Start()
	{
		solvedGoal = GetComponent<SolvedGoal> ();
		timerOn = false;
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
	}
	
	void Update()
	{
		if (timerOn) {
			if (timeLeft == 0) {
				disappearingObject.SetActive (true);
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
			solvedGoal.solved ();
			disappearingObject.SetActive (false);
			if (timed) {
				timeLeft = timeLimit;
				timerOn = true;
				InvokeRepeating("decreaseTimeRemaining", 1f, 1f);
			}
			if (other.tag != "Player") {
				if (!solver.holdingObject) {
					other.transform.position = goalArea.transform.position;
			
				}
			}
		}	
	}

	void OnTriggerExit(Collider other)
	{
		if (toggle) {
			if (other == keyCollider) {
				disappearingObject.SetActive (true);
				resetTime ();
			}
		}
	}

}
