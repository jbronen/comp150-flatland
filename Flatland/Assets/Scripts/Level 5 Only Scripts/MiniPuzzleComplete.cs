using UnityEngine;
using System.Collections;

public class MiniPuzzleComplete : MonoBehaviour {

	public Material newMaterial;
//	public GameObject rightLight;
//	public GameObject leftLight;
	public GameObject goalArea;

	Renderer rend;
	SolvedGoal solvedGoal;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		solvedGoal = goalArea.GetComponent<SolvedGoal> ();
	}

	void Update () 
	{
		if (solvedGoal.isSolved ()) {
			rend.material = newMaterial;
		}
	}
}
