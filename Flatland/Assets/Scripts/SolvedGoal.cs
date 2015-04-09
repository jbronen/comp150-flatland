using UnityEngine;
using System.Collections;

public class SolvedGoal : MonoBehaviour {

	public Material newMaterial;

	Material oldMaterial;
	Renderer rend;
	bool goalSolved;

	void Start() 
	{
		goalSolved = false;
		rend = GetComponent<Renderer> ();
		oldMaterial = rend.material;
	}

	public bool isSolved()
	{
		return goalSolved;
	}

	public void solved()
	{
		goalSolved = true;
		rend.material = newMaterial;
	}

	public void unSolved()
	{
		goalSolved = false;
		rend.material = oldMaterial;
	}
}
