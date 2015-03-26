using UnityEngine;
using System.Collections;

public class DropPlatform : MonoBehaviour {

	GameObject platform;
	GameObject player;
	public float fall_time;
	public bool reappear;
	public float reappear_time;
	BoxCollider trigger_col;
	Rigidbody platform_body;
	bool falling;
	bool timer_on;
	float timer;
	Vector3 initial_position;

	// Use this for initialization
	void Start () {
		platform = this.gameObject;
		player = GameObject.FindGameObjectWithTag ("Player");
		platform_body = platform.GetComponent<Rigidbody> ();
		timer_on = false;
		timer = 0;
		initial_position = platform.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timer_on) {
			timer = timer + Time.fixedDeltaTime;
			if (!falling) {
				if (timer > fall_time) {
					drop();
				}
			} else {
				if (reappear && timer > fall_time + reappear_time) {
					unfall();
				}
			}
		}
	}

	void drop(){
		platform_body.constraints = RigidbodyConstraints.None;
		platform_body.useGravity = true;
		falling = true;
	}

	void unfall() {
		platform_body.constraints = RigidbodyConstraints.FreezeAll;
		platform_body.useGravity = false;
		platform.transform.position = initial_position;
		falling = false;
		timer_on = false;
	}

	void OnTriggerEnter (Collider col){
		if (col == player.GetComponent<SphereCollider> ()) {
			timer = 0;
			timer_on = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (!falling) {
			if (col == player.GetComponent<SphereCollider> ()) {
				timer_on = false;
			}
		}
	}
}
