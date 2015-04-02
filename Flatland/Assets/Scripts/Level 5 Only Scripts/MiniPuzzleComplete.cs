using UnityEngine;
using System.Collections;

public class MiniPuzzleComplete : MonoBehaviour {

	public Material newMaterial;
	public GameObject rightLight;
	public GameObject leftLight;

	Renderer rend;

	void Update () {
		rend = GetComponent<Renderer> ();
		rend.material = newMaterial;
	
	}
}
