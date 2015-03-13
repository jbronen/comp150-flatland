using UnityEngine;
using System.Collections;

public class BridgeKey : MonoBehaviour {

	public GameObject keyObject;
	public GameObject bridge;
	public bool timed;
	public float timeLimit;
	
	PickupObject solver;
	float timeLeft;
	bool timerOn;
	Collider keyCollider;
	
	void Start()
	{
		timerOn = false;
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
	}

	void Update()
	{
		if (timerOn) {
			if (timeLeft == 0) {
				bridge.SetActive (false);
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
			if (bridge.activeSelf == false) {
				bridge.SetActive (true);
				if (timed) {
					timeLeft = timeLimit;
					timerOn = true;
					InvokeRepeating("decreaseTimeRemaining", 1f, 1f);
				}
			}
			if (!solver.holdingObject) {
				other.transform.position = keyObject.transform.position;
			}
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other == keyCollider) {
			bridge.SetActive (false);
			resetTime();
		}
	}
}
