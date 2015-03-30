using UnityEngine;
using System.Collections;

public class LinkedShapeSwitch : MonoBehaviour {

	public GameObject thisParent;
	public GameObject linkedParent;
	public int max_shapes;
	string parent_name;
	GameObject [] shapes;
	string held_name;
	bool held;
	int shapenum;
	Transform [] temp;
	//int maxshapes = 3;
	PickupObject pickupObject;
	LinkedShapeSwitch linkedShapeSwitch;
	
	// Use this for initialization
	void Start () {
		
		shapenum = 0;
		GameObject player = GameObject.FindWithTag ("Player");
		if (player != null) {
			pickupObject = player.GetComponent <PickupObject>();
		}
		parent_name = thisParent.ToString ();
		temp = thisParent.GetComponentsInChildren<Transform>();
		for (int j = 0; j < temp.Length; j++) {
			Debug.Log (temp [j]);
		}
		//Debug.Log (temp.Length);
		shapes = new GameObject[max_shapes];
		for (int i = 0; i < temp.Length; i++) {
			/*if (temp [i].gameObject.ToString ().Substring (0,4) == parent_name.Substring(0,4)) {
                shapes [shapenum] = temp [i].gameObject;
                shapenum++;
            }*/
			if (temp[i].gameObject.ToString() != parent_name) {
				shapes[shapenum] = temp[i].gameObject;
				shapenum++;
			}
		}
		shapenum = 0;
		for (int i = 1; i < shapes.Length; i++) {
			shapes [i].SetActive (false);
		}
		for (int i = 0; i < shapes.Length; i++) {
			Debug.Log(parent_name);
			Debug.Log (shapes [i].ToString ());
		}
		linkedShapeSwitch = linkedParent.GetComponent<LinkedShapeSwitch> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (pickupObject.holdingObject) {
			//Debug.Log(shapes[shapenum].ToString());
			//Debug.Log (pickupObject.carriedObject.ToString());
			held_name = shapes[shapenum].ToString();
			if (pickupObject.carriedObject.ToString() == held_name) {
				held = true;
			} else {
				held = false;
			}
		} else {
			held = false;
		}
		if (held) {
			if (Input.GetMouseButtonDown(1)) {
				thisSwitch();
				linkedShapeSwitch.linkedSwitch();
			}
		}
	}

	void thisSwitch (){
		pickupObject.drop ();
		shapenum = (shapenum + 1) % shapes.Length;
		Debug.Log (shapenum);
		Debug.Log (shapes [0].ToString ());
		if (shapenum == 0) {
			//Debug.Log ("SHAPE 0 is " + gameObject.ToString());
			shapes [0].transform.position = shapes [shapes.Length - 1].transform.position;
			shapes [0].SetActive (true);
			shapes [shapes.Length - 1].SetActive (false);
			pickupObject.hold (shapes [0]);
		} else {
			//Debug.Log ("SHAPE 1 is " + gameObject.ToString());
			shapes [shapenum].transform.position = shapes [shapenum - 1].transform.position;
			shapes [shapenum - 1].SetActive (false);
			shapes [shapenum].SetActive (true);
			pickupObject.hold (shapes [shapenum]);
		}
	}

	public void linkedSwitch () {
		shapenum = (shapenum + 1) % shapes.Length;
		Debug.Log (shapenum);
		Debug.Log (shapes [0].ToString ());
		if (shapenum == 0) {
			//Debug.Log ("SHAPE 0 is " + gameObject.ToString());
			shapes [0].transform.position = shapes [shapes.Length - 1].transform.position;
			shapes [0].SetActive (true);
			shapes [shapes.Length - 1].SetActive (false);
		} else {
			//Debug.Log ("SHAPE 1 is " + gameObject.ToString());
			shapes [shapenum].transform.position = shapes [shapenum - 1].transform.position;
			shapes [shapenum - 1].SetActive (false);
			shapes [shapenum].SetActive (true);
		}
	}

}