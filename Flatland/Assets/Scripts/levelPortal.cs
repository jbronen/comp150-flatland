using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelPortal : MonoBehaviour {

	public string sceneName;
	public Animator fader;

	GameController gameController;

	void Start () 
	{
		fader.SetBool("transitioning", false);
		gameController = GameObject.FindWithTag("GameController").GetComponent <GameController> ();

	}

	void OnTriggerEnter(Collider other)
	{
		if (gameController.solved()) {
			if (other.transform.tag == "Player") {
				EndScene();
			}
		}
	}

	void EndScene()
	{
		fader.SetBool ("transitioning", true);
		StartCoroutine (waitForAnimation());
	}

	IEnumerator waitForAnimation()
	{
		yield return new WaitForSeconds (2);
		Application.LoadLevel (sceneName);
	}
}