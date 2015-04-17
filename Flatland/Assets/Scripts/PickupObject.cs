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
	public Text reticle;
	public float rotateSpeed;

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
	
	void Start()
	{
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
	}

	void Update()
	{
		if (holdingObject) {
			rotate (carriedObject);
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
	
	void checkForRotate () {
		dummy = carriedObject.transform;
		dummy.LookAt (new Vector3 (mainCamera.transform.position.x, dummy.transform.position.y, mainCamera.transform.position.z));
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			int temp = right;
			right = front;
			front = 7 - temp;
		}  
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			int temp = front;
			front = right;
			right = 7 - temp;
			
		}  
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			int temp = front;
			front = top;
			top = 7 - temp;
		}  
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			int temp = top;
			top = front;
			front = 7 - temp;
		}
		rotate (carriedObject);
	}
	
	void rotate(GameObject o)
	{
		//use rotation vector (x,y,z)
		//calculate vector from o.position to maincamera.position
		//rotate vector by rotation vector
		//calculate point to look at for LookAt function
		//use LookAt function
		dummy = o.transform;
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			int temp = right;
			right = front;
			front = 7-temp;
		}  
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			int temp = front;
			front = right;
			right = 7-temp;
		}  
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			int temp = top;
			top = front;
			front = 7-temp;
		}  
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			int temp = front;
			front = top;
			top = 7-temp;
		}
		dummy.LookAt (new Vector3 (mainCamera.transform.position.x, o.transform.position.y, mainCamera.transform.position.z));
		rotation_vec = rotations [top-1,right-1];
		dummy.rotation = Quaternion.AngleAxis (rotation_vec.x, dummy.right)*dummy.rotation;
		dummy.rotation = Quaternion.AngleAxis (rotation_vec.y, dummy.up)*dummy.rotation;
		dummy.rotation = Quaternion.AngleAxis (rotation_vec.z, dummy.forward)*dummy.rotation;
		o.transform.rotation = Quaternion.Slerp(o.transform.rotation, dummy.rotation,Time.fixedDeltaTime);
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
					reticle.color = Color.green; 
					pickupText.text = "Left-Click to Pick Up";
				}  else {
					pickupText.text = "";
				}
			}  else {
				pickupText.text = "";
				reticle.color = Color.red;
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
		rotations [4, 0] = new Vector3 (-90, -90, 0);
		rotations [4, 2] = new Vector3 (0, 0, 90);
		rotations [4, 3] = new Vector3 (0, 180, 90);
		rotations [4, 5] = new Vector3 (90, 90, 0);
		rotations [5, 1] = new Vector3 (90, 0, 0);
		rotations [5, 2] = new Vector3 (90, 0, 90);
		rotations [5, 3] = new Vector3 (90, 0, -90);
		rotations [5, 4] = new Vector3 (90, 0, 180);
	}
	
	public int getFront() {
		return front;
	}
}

