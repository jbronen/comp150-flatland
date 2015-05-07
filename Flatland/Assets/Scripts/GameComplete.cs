using UnityEngine;
using System.Collections;

public class GameComplete : MonoBehaviour {

	public void returnToMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
}
