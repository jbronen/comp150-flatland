using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour {
	
	public GameObject keyObject;
	public GameObject door;
	
	Collider keyCollider;
	
	void Start()
	{
		keyCollider = keyObject.GetComponent<Collider> ();
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other == keyCollider) {
			
			door.SetActive (false);
		}
	}
}
