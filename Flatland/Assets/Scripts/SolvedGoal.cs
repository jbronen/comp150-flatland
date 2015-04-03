using UnityEngine;
using System.Collections;

public class SolvedGoal : MonoBehaviour {

	public Material newMaterial;

	Material oldMaterial;
	Renderer rend;
//	bool goalSolved;

	void Start() 
	{
		//goalSolved = false;
		rend = GetComponent<Renderer> ();
		oldMaterial = rend.material;
	}

//	void Update () 
//	{
//		if (goalSolved) {
//			rend.material = newMaterial;
//		}
//	}

	public void solved()
	{
		//goalSolved = true;
		rend.material = newMaterial;
	}

	public void unSolved()
	{
		rend.material = oldMaterial;
	}
}
