using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public GameObject mainMenuPanel;

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void NewGame()
	{
		Application.LoadLevel ("DigitalPrototype");
	}

}
