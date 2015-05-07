using UnityEngine;
using System.Collections;

public class Level4ControlScript : MonoBehaviour {

	public GameObject square;
	public GameObject cylinder;

	public GameObject squarePlatform1;
	public GameObject squarePlatform2;
	public GameObject cylPlatform1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (square.activeSelf) {
			squarePlatform1.SetActive (true);
			squarePlatform2.SetActive (true);
			cylPlatform1.SetActive (false);
		} else {
			squarePlatform1.SetActive (false);
			squarePlatform2.SetActive (false);
			cylPlatform1.SetActive (true); 
		}
	}
}
