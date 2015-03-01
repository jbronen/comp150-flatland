using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour {
	
	GameObject mainCamera;
	public GameObject carriedObject;
	float distanceToObject;

	public bool holdingObject = false;
	public float distance;
	public float smooth;
	public Text pickupText;
	public Text transformText;
	public float rotateSpeed;

	void Start()
	{
		pickupText.text = "";
		transformText.text = "";
		mainCamera = GameObject.FindWithTag ("MainCamera");
	}

	void FixedUpdate()
	{
		if (holdingObject) {
			pickupText.text = "";
			transformText.text = "RMB to Transform";
			carry(carriedObject);
			rotate(carriedObject);
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

	void rotate(GameObject o)
	{
		if (Input.GetKey (KeyCode.RightArrow)) {
			o.transform.Rotate (-Vector3.up * rotateSpeed * Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.LeftArrow)) {
			o.transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.UpArrow)) {
			o.transform.Rotate (Vector3.right * rotateSpeed * Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.DownArrow)) {
			o.transform.Rotate (-Vector3.right * rotateSpeed * Time.deltaTime);
		}
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
