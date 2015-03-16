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
	AudioSource [] sfx;
	AudioClip sound_effect;
	//AudioSource source;

	void Start()
	{
		pickupText.text = "";
		transformText.text = "";
		mainCamera = GameObject.FindWithTag ("MainCamera");
		sfx = new AudioSource[5];
		sfx[0] = GameObject.Find ("pickup").GetComponent<AudioSource>();
		sfx [1] = GameObject.Find ("drop").GetComponent<AudioSource> ();
		//source = GameObject.FindWithTag ("Sound Effect").GetComponent<AudioSource> ();
		Debug.Log (GameObject.FindWithTag ("Sound Effect"));
	}

	void FixedUpdate()
	{
		if (holdingObject) {
			pickupText.text = "";
			transformText.text = "Right Click to Change";
			carry(carriedObject);
			rotate(carriedObject);
			if (Input.GetMouseButtonDown (0)) {
				drop();
				sfx [1].Play ();
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

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Pickup") {
					distanceToObject = Vector3.Distance(transform.position, hit.transform.position); 
					if (distanceToObject < distance) {
						hit.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
						hold (hit.collider.gameObject);
						sfx [0].Play ();
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
		o.GetComponent<Rigidbody>().useGravity = false;
	}

	public void drop()
	{
		holdingObject = false;
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		//carriedObject.rigidbody.isKinematic = false;
		carriedObject = null;
	}

	void checkForPickup()
	{
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "Pickup") {
				float distanceToObject = Vector3.Distance (transform.position, hit.transform.position);
				if (distanceToObject < distance) {
					pickupText.text = "Left Click to Pick Up";
				} else {
					pickupText.text = "";
				}
			} else {
				pickupText.text = "";
			}
		} 
	}
}
