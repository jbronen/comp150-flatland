using UnityEngine;
using System.Collections;

public class SolvedGoal : MonoBehaviour {

	public Material newMaterial;

	Renderer rend;
	bool goalSolved;

	void Start() 
	{
		goalSolved = false;
		rend = GetComponent<Renderer> ();
	}

	void Update () 
	{
		if (goalSolved) {
			rend.material = newMaterial;
		}
	}

	public void solved()
	{
		goalSolved = true;
		rend.material = newMaterial;
	}
}
