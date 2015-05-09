using UnityEngine;
using System.Collections;

public class GameComplete : MonoBehaviour {

	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void returnToMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
}
