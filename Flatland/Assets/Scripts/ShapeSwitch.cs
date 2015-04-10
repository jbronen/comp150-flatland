
using UnityEngine;
using System.Collections;

public class ShapeSwitch : MonoBehaviour {

	public GameObject parent;
	public int max_shapes;
	string parent_name;
	GameObject [] shapes;
	string held_name;
	bool held;
	int shapenum;
	Transform [] temp;
	PickupObject pickupObject; 

	void Start () {
		
		shapenum = 0;
		GameObject player = GameObject.FindWithTag ("Player");
		if (player != null) {
			pickupObject = player.GetComponent <PickupObject>();
		}
		parent_name = parent.ToString ();
		temp = parent.GetComponentsInChildren<Transform>();
		shapes = new GameObject[max_shapes];
		for (int i = 0; i < temp.Length; i++) {
			if (temp[i].gameObject.ToString() != parent_name) {
				shapes[shapenum] = temp[i].gameObject;
				shapenum++;
			}
		}
		shapenum = 0;
		for (int i = 1; i < shapes.Length; i++) {
			shapes [i].SetActive (false);
		}
	}

	void Update () {
		if (pickupObject.holdingObject) {
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
				pickupObject.drop();
				shapenum = (shapenum + 1) % shapes.Length;
				if (shapenum == 0) {
					shapes[0].transform.position = shapes[shapes.Length-1].transform.position + new Vector3(0,shapes[0].transform.localScale.y,0);
					shapes[0].SetActive (true);
					shapes[shapes.Length-1].SetActive (false);
					pickupObject.hold (shapes[0]);
					shapes[0].layer = 8;

				} else {
					shapes[shapenum].transform.position = shapes[shapenum-1].transform.position;
					shapes[shapenum-1].SetActive (false);
					shapes[shapenum].SetActive (true);
					pickupObject.hold (shapes[shapenum]);
					shapes[shapenum].layer = 8;
				}
			}
		}
	}
}