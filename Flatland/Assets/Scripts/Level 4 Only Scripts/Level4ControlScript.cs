using UnityEngine;
using System.Collections;

public class Level4ControlScript : MonoBehaviour {

	public GameObject square;
	public GameObject cylinder;

	public GameObject squarePlatform1;
	public GameObject squarePlatform2;
	public GameObject cylPlatform1;

	public GameObject movesq1;
	public GameObject movecyl2;
	public GameObject movesq2;

	public GameObject sq1;
	public GameObject cyl1;
	public GameObject cyl2;
	public GameObject sq2;
	public GameObject cyl3;
	public GameObject sq3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (square.activeSelf) {
			squarePlatform1.SetActive (true);
			squarePlatform2.SetActive (true);
			cylPlatform1.SetActive (false);
			movesq1.SetActive(true);
			movesq2.SetActive(true);
			movecyl2.SetActive(false);
			sq1.SetActive(true);
			cyl1.SetActive(false);
			cyl2.SetActive(false);
			sq2.SetActive(true);
			cyl3.SetActive(false);
			sq3.SetActive(true);
		} else {
			squarePlatform1.SetActive (false);
			squarePlatform2.SetActive (false);
			cylPlatform1.SetActive (true);
			movesq1.SetActive(false);
			movesq2.SetActive(false);
			movecyl2.SetActive(true);
			sq1.SetActive(false);
			cyl1.SetActive(true);
			cyl2.SetActive(true);
			sq2.SetActive(false);
			cyl3.SetActive(true);
			sq3.SetActive(false);
		}
	}
}
