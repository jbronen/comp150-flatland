using UnityEngine;
using System.Collections;

public class BridgeKey : MonoBehaviour {

	public GameObject keyObject;
	public GameObject bridge;
	
	private PickupObject solver;
	Collider keyCollider;
	
	void Start()
	{
		solver = GameObject.FindWithTag ("Player").GetComponent<PickupObject> ();
		keyCollider = keyObject.GetComponent<Collider> ();
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other == keyCollider) {
			if (bridge.activeSelf == false) {
				bridge.SetActive (true);
			}
			if (!solver.holdingObject) {
				other.transform.position = keyObject.transform.position;
				//other.transform.position = new Vector3 (keyObject.transform.position.x, keyObject.transform.position.y + .1f, keyObject.transform.position.z);
			}
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other == keyCollider) {
			bridge.SetActive (false);
		}
	}
}
