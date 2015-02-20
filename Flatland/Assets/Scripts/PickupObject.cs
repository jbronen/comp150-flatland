using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

	public bool holdingObject = false;
	GameObject mainCamera;
	GameObject carriedObject;
	public float distance;
	public float smooth;

	void Start()
	{
		mainCamera = GameObject.FindWithTag ("MainCamera");
	}

	void Update()
	{
		if (holdingObject) {
			carry(carriedObject);
			if (Input.GetMouseButtonDown (0)) {
				drop();
			}
		} else {
			pickup();
		}
	}
	
	void carry(GameObject o)
	{
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}

	void pickup()
	{
		if (Input.GetMouseButtonDown (0)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.camera.ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Pickup") {
					float distanceToObject = Vector3.Distance(transform.position, hit.transform.position); 

					if (distanceToObject < distance) {
						holdingObject = true;
						carriedObject = hit.collider.gameObject;
						hit.collider.gameObject.rigidbody.useGravity = false;
						//hit.collider.gameObject.rigidbody.isKinematic = true;
					}
				}
			}
		}

	}

	public void switchPickUp () {
		int x = Screen.width / 2;
		int y = Screen.height / 2;
		Ray ray = mainCamera.camera.ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "Pickup") {
				float distanceToObject = Vector3.Distance(transform.position, hit.transform.position); 
				
				if (distanceToObject < distance) {
					holdingObject = true;
					carriedObject = hit.collider.gameObject;
					hit.collider.gameObject.rigidbody.useGravity = false;
					//hit.collider.gameObject.rigidbody.isKinematic = true;
				}
			}
		}
	}

	public void drop()
	{
		holdingObject = false;
		carriedObject.rigidbody.useGravity = true;
		//carriedObject.rigidbody.isKinematic = false;
		carriedObject = null;

	}
}
