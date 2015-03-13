using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public float middle;
	public float width;
	public string axis;
	bool should_move;
	Vector3 movement;
	//Vector3 axis_vec;
	int axis_int;
	float offset;
	float initialPosition;
	bool first_time = true;

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void FixedUpdate () {
		if (should_move) {
			movement = platform.transform.position;
			movement[axis_int] = middle + width * Mathf.Sin (2*Mathf.PI*1/20*(Time.time-offset)); 
			platform.transform.position = Vector3.Lerp(platform.transform.position,movement,Time.fixedDeltaTime);
		} else {
			if (!first_time) {
				offset = offset + Time.fixedDeltaTime;
			}
		}
	}

	public void move(bool set) {
		should_move = set;
		first_time = false;
	}
}
