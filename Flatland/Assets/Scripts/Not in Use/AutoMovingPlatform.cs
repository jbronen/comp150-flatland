using UnityEngine;
using System.Collections;

public class AutoMovingPlatform : MonoBehaviour {
	
	public GameObject platform;
	public float middle;
	public float width;
	//public float speed;
	public string axis;
	public bool neg_start;

	Vector3 movement;
	int axis_int;
	float offset;
	float initialPosition;

	void Start () {
		if (axis == "x") {
			initialPosition = platform.transform.position.x;
			axis_int = 0;
		} else if (axis == "y") {
			initialPosition = platform.transform.position.y;
			axis_int = 1;
		} else if (axis == "z") {
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

	void Update () {
		movement = platform.transform.position;
		if (neg_start) {
			movement [axis_int] = -(middle + width * Mathf.Sin (2 * Mathf.PI * 1 / 20 * (Time.time - offset))); 
		} else {
			movement [axis_int] = middle + width * Mathf.Sin (2 * Mathf.PI * 1 / 20 * (Time.time - offset));
		}
		platform.transform.position = Vector3.Lerp(platform.transform.position,movement,Time.fixedDeltaTime);
	}

}