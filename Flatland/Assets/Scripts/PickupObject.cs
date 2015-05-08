using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour {

	public GameObject carriedObject;
	public bool holdingObject = false;
	public float holdingDistance;
	public float pickupDistance;
	public float smooth;
	public Text pickupText;
	public Text transformText;
	public Text regularReticle;
	public Image pickupReticle;
	public float rotateSpeed = 0.9F;

	float distanceToObject;
	GameObject mainCamera;
	GameObject attemptedPickup;
	bool hitPickup;
	AudioSource [] sfx;
	AudioClip sound_effect;
	Vector3 look_at_vector;
	Transform dummy;
	Vector3 [,] rotations;
	int rotation_num;
	int top, right, front;
	Vector4 rotation_vec;
	public Transform toRotation;
	bool Rotating = false;
	bool Rotate = false;
	bool side = true;
	int presses = 0;
	int direction = 1;
	int x = 0, y = 0, z = 0;


	void Start()
	{
		pickupReticle.enabled = false;
		hitPickup = false;
		pickupText.text = "";
		transformText.text = "";
		mainCamera = GameObject.FindWithTag ("MainCamera");
		sfx = new AudioSource[5];
		sfx[0] = GameObject.Find ("pickup").GetComponent<AudioSource>();
		sfx [1] = GameObject.Find ("drop").GetComponent<AudioSource> ();
		rotations = new Vector3[6,6];
		load_rotations();
		
		top = 3; //imagine a die with 1 facing towards you, 3 facing up, and 2 facing right
		right = 2;
		front = 1;
		
		rotation_vec = new Vector3 (0, 0, 0);
		dummy = toRotation.transform; 
	}

	void Update()
	{
		if (holdingObject) {
			//dummy = carriedObject.transform;
			rotate (carriedObject);
			//checkForRotate();
			if (Input.GetMouseButtonDown (0)) {
				drop ();
			}
		} else {
			attemptedPickup = null;
			checkForPickup ();
			pickup ();
		}
	}
	
	void FixedUpdate()
	{
		if (holdingObject) {
			pickupText.text = "";
			transformText.text = "Right-Click to Change";
			carry(carriedObject);
		}  else {
			transformText.text = "";
		}
	}
	
	void carry(GameObject o)
	{
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * holdingDistance, Time.deltaTime * smooth);
	}

	
	void rotate(GameObject o)
	{
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//presses = (presses+1)%4;
			Rotate = true;
			toRotation.transform.Rotate (Vector3.up, -90, Space.World);
			int temp = right;
			right = front;
			front = 7-temp;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			//presses = (presses+1)%4;
			Rotate = true;
			toRotation.transform.Rotate (Vector3.up, 90, Space.World);
			int temp = front;
			front = right;
			right = 7-temp;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//presses = (presses+1)%4;
			if (right == 1) {
				toRotation.transform.Rotate (toRotation.transform.forward, direction*90, Space.World);
			} else if (right == 2) {
				toRotation.transform.Rotate (toRotation.transform.right, -direction*90, Space.World);
			} else if (right == 3) {
				toRotation.transform.Rotate (toRotation.transform.up, -direction*90, Space.World);
			} else if (right == 4) {
				toRotation.transform.Rotate (toRotation.transform.up, direction*90, Space.World);
			} else if (right == 5) {
				toRotation.transform.Rotate (toRotation.transform.right, direction*90, Space.World);
			} else if (right == 6) {
				toRotation.transform.Rotate (toRotation.transform.forward, -direction*90, Space.World);
			}
			int temp = top;
			top = front;
			front = 7-temp;
			Rotate = true;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//presses = (presses+1)%4;
			if (right == 1) {
				toRotation.transform.Rotate (toRotation.transform.forward, -direction*90, Space.World);
			} else if (right == 2) {
				toRotation.transform.Rotate (toRotation.transform.right, direction*90, Space.World);
			} else if (right == 3) {
				toRotation.transform.Rotate (toRotation.transform.up, direction*90, Space.World);
			} else if (right == 4) {
				toRotation.transform.Rotate (toRotation.transform.up, -direction*90, Space.World);
			} else if (right == 5) {
				toRotation.transform.Rotate (toRotation.transform.right, -direction*90, Space.World);
			} else if (right == 6) {
				toRotation.transform.Rotate (toRotation.transform.forward, direction*90, Space.World);
			}
			int temp = front;
			front = top;
			top = 7-temp;
			Rotate = true;
		}
		if (Rotate) {
			//to.rotation = Quaternion.AngleAxis (90, direction*Vector3.up)*to.rotation;
			o.transform.rotation = Quaternion.Slerp (o.transform.rotation, toRotation.rotation, 0.002F*rotateSpeed);
			Debug.Log (o.transform.rotation);
		}
		if (o.transform.rotation == toRotation.rotation) {
			Rotate = false;
			//direction = 0;
		}
		
		if (!Rotate) {
			rotation_vec = rotations[top-1,right-1];
			dummy = o.transform;
			dummy.transform.LookAt (new Vector3 (mainCamera.transform.position.x, o.transform.position.y, mainCamera.transform.position.z));
			/*dummy.transform.Rotate(dummy.transform.right, 90*x, Space.World);
			dummy.transform.Rotate(Vector3.up, 90*y, Space.World);
			dummy.transform.Rotate(dummy.transform.forward, 90*z, Space.World);*/
			dummy.transform.Rotate(dummy.transform.right, rotation_vec.x, Space.World);
			dummy.transform.Rotate(Vector3.up, rotation_vec.y, Space.World);
			dummy.transform.Rotate(dummy.transform.forward, rotation_vec.z, Space.World);
			toRotation.transform.rotation = dummy.transform.rotation;
			o.transform.rotation = dummy.transform.rotation;
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
					if (distanceToObject < pickupDistance) {
						attemptedPickup = hit.collider.gameObject;
						hit.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
						hit.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
						hold (hit.collider.gameObject);
						hit.collider.gameObject.layer = 8;
						sfx [0].Play ();
					}
				}
			}
		}
		
		
	}

	public bool pickingUp(GameObject o)
	{
		if (o == attemptedPickup) {
			hitPickup = true;
		} else {
			hitPickup = false;
		}
		return hitPickup;
	}
	
	public void hold (GameObject o)
	{
		holdingObject = true;
		carriedObject = o;
		o.GetComponent<Rigidbody>().useGravity = false;
	}
	
	public void drop()
	{
		sfx [1].Play ();
		hitPickup = false;
		holdingObject = false;
		carriedObject.layer = 9;
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		carriedObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		carriedObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
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
				if (distanceToObject < pickupDistance) {
					//reticle.color = Color.green; 
					pickupReticle.enabled = true;
					regularReticle.enabled = false;
					pickupText.text = "Left-Click to Pick Up";
				}  else {
					pickupText.text = "";
				}
			}  else {
				pickupText.text = "";
				//reticle.color = Color.red;
				regularReticle.enabled = true;
				pickupReticle.enabled = false;
			}
		}  
	}
	
	void load_rotations() {
		rotations [0, 1] = new Vector3 (-90, 0, 0);
		rotations [0, 2] = new Vector3 (-90, 0, 90);
		rotations [0, 3] = new Vector3 (-90, 0, -90);
		rotations [0, 4] = new Vector3 (-90, 0, 180);
		rotations [1, 0] = new Vector3 (0, -90, -90);
		rotations [1, 2] = new Vector3 (0, 180, -90);
		rotations [1, 3] = new Vector3 (0, 0, -90);
		rotations [1, 5] = new Vector3 (0, 90, -90);
		rotations [2, 0] = new Vector3 (0, -90, 0);
		rotations [2, 1] = new Vector3 (0, 0, 0);
		rotations [2, 4] = new Vector3 (0, 180, 0);
		rotations [2, 5] = new Vector4 (0, 90, 0);
		rotations [3, 0] = new Vector4 (0, -90, 180);
		rotations [3, 1] = new Vector3 (180, 0, 0);
		rotations [3, 4] = new Vector3 (0, 0, 180);
		rotations [3, 5] = new Vector3 (0, 90, 180);
		rotations [4, 0] = new Vector3 (0, -90, 90);
		rotations [4, 2] = new Vector3 (0, 0, 90);
		rotations [4, 3] = new Vector3 (0, 180, 90);
		rotations [4, 5] = new Vector3 (0, 90, 90);
		rotations [5, 1] = new Vector3 (90, 0, 0);
		rotations [5, 2] = new Vector3 (90, 0, 90);
		rotations [5, 3] = new Vector3 (90, 0, -90);
		rotations [5, 4] = new Vector3 (90, 0, 180);
	}
	
	public int getFront() {
		return front;
	}
}

