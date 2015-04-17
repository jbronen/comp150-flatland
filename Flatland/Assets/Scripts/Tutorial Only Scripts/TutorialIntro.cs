using UnityEngine;
using System.Collections;

public class TutorialIntro : MonoBehaviour {

	public Camera cinematicCamera;
	public Camera mainCamera;
	public Canvas tutorialUI;

	void Start () 
	{
		Time.timeScale = 0;

		mainCamera.enabled = false;
		cinematicCamera.enabled = true;
	
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
			tutorialUI.enabled = false;
			Time.timeScale = 1;
			mainCamera.enabled = true;
			cinematicCamera.enabled = false;
		}
	}
}
