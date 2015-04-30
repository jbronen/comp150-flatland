using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialPuzzleComplete : MonoBehaviour {

	GameController gameController;
//	GameObject fader;
//	Image faderImage;
	
	public GameObject door;
	public GameObject levelPortal;
	
	void Start ()
	{
//		fader = GameObject.FindWithTag ("Fader");
//		faderImage = fader.GetComponent<Image> ();
//		faderImage.color.a = 0;
		gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
	}
	
	void Update()
	{
		if (door.activeSelf == false) {
			gameController.puzzleCompleted();
			levelPortal.SetActive(true);
		}
	}
}
