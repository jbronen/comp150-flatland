
using UnityEngine;
using System.Collections;

public class ShapeSwitch : MonoBehaviour {
	
	public GameObject shape0;
	public GameObject shape1;
	public GameObject shape2;
	bool held;
	//GameObject[] shapes;
	int shapenum;
	int maxshapes = 3;
	PickupObject pickupObject; 


	public ShapeSwitch (GameObject s0, GameObject s1, GameObject s2)
	{
		shape0 = s0;
		shape1 = s1;
		shape2 = s2;
	}


	// Use this for initialization
	void Start () {
		/*shapes = new GameObject[3];
		shapes[0] = shape0;
		shapes[1] = shape1;
		shapes[2] = shape2;*/
		shapenum = 0;
		//held = false;
		GameObject player = GameObject.FindWithTag ("Player");
		if (player != null) {
			pickupObject = player.GetComponent <PickupObject>();
		}
		shape0.SetActive (true);
		shape1.SetActive (false);
		shape2.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//pickupObject = GetComponent<PickupObject>();
		held = pickupObject.holdingObject;
		if (held) {
			if (Input.GetMouseButtonDown(1)) {
				pickupObject.drop();
				shapenum = (shapenum + 1) % maxshapes;
				if (shapenum == 0) {
					Debug.Log (gameObject.ToString());
					shape0.transform.position = shape2.transform.position;//, shape2.transform.position);
					shape0.SetActive (true);
					shape1.SetActive (false);
					shape2.SetActive (false);
					pickupObject.hold (shape0);
				} else if (shapenum == 1) {
					shape1.transform.position = shape0.transform.position;
					shape0.SetActive (false);
					shape1.SetActive (true);
					shape2.SetActive (false);
					pickupObject.hold (shape1);
				} else if (shapenum == 2) {
					shape2.transform.position = shape1.transform.position;
					shape0.SetActive (false);
					shape1.SetActive (false);
					shape2.SetActive (true);
					pickupObject.hold (shape2);
				}
			}
		}
	}
}
