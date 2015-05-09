using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
	
	Rigidbody rb;
	PickupObject pickupObject;
	ResetShapePosition rsp;
	
	// Use this for initialization
	void Start () {
		pickupObject = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickupObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider col) {
		rb = col.gameObject.GetComponent<Rigidbody>();
		rsp = col.gameObject.GetComponent<ResetShapePosition> ();
		if (col.gameObject.tag == "Pickup") {
			if (pickupObject.holdingObject) {
				pickupObject.drop ();
			}
			if (rsp != null) {
				if (rsp.getPosition().x >= col.transform.position.x) {
					rb.velocity = new Vector3(5,5,0);
				} else {
					rb.velocity = new Vector3(-5,5,0);
				}
			}else {
				if (rb.transform.position.x >= col.transform.position.x) {
					rb.velocity = new Vector3(5, 5, 0);
				} else {
					rb.velocity = new Vector3(-5, 5, 0);
				}
			}
		}
	}
}
