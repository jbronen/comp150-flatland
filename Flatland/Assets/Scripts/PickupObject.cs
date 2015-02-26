using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour {
	
	GameObject mainCamera;
	GameObject carriedObject;
	float distanceToObject;

	public bool holdingObject = false;
	public float distance;
	public float smooth;
	public Text pickupText;
	public Text transformText;

	void Start()
	{
		pickupText.text = "";
		transformText.text = "";
		mainCamera = GameObject.FindWithTag ("MainCamera");
	}

	void Update()
	{
		if (holdingObject) {
			pickupText.text = "";
			transformText.text = "RMB to Transform";
			carry(carriedObject);
			if (Input.GetMouseButtonDown (0)) {
				drop();
			}
		} else {
			transformText.text = "";
			checkForPickup();
			pickup();
		}
	}
	
	void carry(GameObject o)
	{
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		//o.transform.rotation = Vector3.Lerp (o.transform.rotation, mainCamera.transform.rotation, Time.deltaTime * smooth);
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
					distanceToObject = Vector3.Distance(transform.position, hit.transform.position); 
					if (distanceToObject < distance) {
						hold (hit.collider.gameObject);
						//hit.collider.gameObject.rigidbody.isKinematic = true;
					}
				}
			}
		}

	}

	public void hold (GameObject o)
	{
		holdingObject = true;
		carriedObject = o;
		o.rigidbody.useGravity = false;
	}

	public void drop()
	{
		holdingObject = false;
		carriedObject.rigidbody.useGravity = true;
		//carriedObject.rigidbody.isKinematic = false;
		carriedObject = null;
	}

	void checkForPickup()
	{
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.camera.ScreenPointToRay (new Vector3 (x, y));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "Pickup") {
				float distanceToObject = Vector3.Distance (transform.position, hit.transform.position);
				if (distanceToObject < distance) {
					pickupText.text = "LMB to Pick Up";
				} else {
					pickupText.text = "";
				}
			} else {
				pickupText.text = "";
			}
		} 
	}
}
