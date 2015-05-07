using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public float middle;
	public float width;
	public string axis;
	public bool should_move;
	public int waitTime;

	Vector3 movement;
	//Vector3 axis_vec;
	int axis_int;
	float offset;
	float initialPosition;
	bool first_time = true;
	bool doneWaiting = false;
	
	void Start () 
	{
		if (waitTime == 0) {
			doneWaiting = true;
		}
		if (axis == "x") {
			//axis_vec = new Vector3 (1, 0, 0);
			initialPosition = platform.transform.position.x;
			axis_int = 0;
		} else if (axis == "y") {
			//axis_vec = new Vector3 (0, 1, 1);
			initialPosition = platform.transform.position.y;
			axis_int = 1;
		} else if (axis == "z") {
			//axis_vec = new Vector3 (0, 0, 1);
			initialPosition = platform.transform.position.z;
			axis_int = 2;
		} else {
			Debug.Log ("Invalid Axis Name in MovingPlatform!");
			initialPosition = 0;
		}

		movement = new Vector3(0,0,0);

		if (initialPosition <= 0) {
			offset = Mathf.Asin ((initialPosition - middle) / width) / (2 * Mathf.PI * 1 / 20);

		} else {
			offset = 20 - Mathf.Asin ((initialPosition - middle) / width) / (2 * Mathf.PI * 1 / 20);
		}

	}

	void FixedUpdate ()
	{
		if ((should_move) && (first_time)) {
			StartCoroutine (waitToStart ());
			first_time = false;
		}
		if ((should_move) && (doneWaiting)) {
			movement = platform.transform.position;
			movement[axis_int] = middle + width * Mathf.Sin (2*Mathf.PI*1/20*(Time.time-offset)); 
			platform.transform.position = Vector3.Lerp(platform.transform.position,movement,Time.fixedDeltaTime);
		} else {
			if (!first_time) {
				offset = offset + Time.fixedDeltaTime;
			}
		}
	}

	public void move(bool set) 
	{
		should_move = set;
		first_time = false;
	}

	IEnumerator waitToStart()
	{
		yield return new WaitForSeconds (2);
		doneWaiting = true;
	}
}
