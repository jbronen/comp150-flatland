using UnityEngine;
using System.Collections;

public class delayScript : MonoBehaviour {
	public Animator control;
	public float delay;

//	AnimationClip anim;
	
	void Start () 
	{
		//anim = control.GetComponent<AnimationClip> ();
		StartCoroutine ("delayStart");
		control.Play ("pyramidPathAnim2");
	}

	IEnumerator delayStart() 
	{
		yield return new WaitForSeconds(delay);
	}

}
