using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	public GameObject pauseMenuPanel;
	public GameObject controlsMenuPanel;
	public GameObject helpMenuPanel;
	public GameObject hintsMenuPanel;
	public GameObject player;

	private bool isPaused = false;

	void Start () {
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape) && !isPaused) {
			PauseGame ();
		} else if (Input.GetKeyUp (KeyCode.Escape) && isPaused) {
			UnpauseGame ();
		}
	}

	public void PauseGame()
	{
		//pause game
		isPaused = true;
		Time.timeScale = 0;

		//disable fps controls
		player.transform.GetComponent<MouseLook> ().enabled = false;
		Camera.main.GetComponent<MouseLook> ().enabled = false;

		//show cursor
		Cursor.lockState = CursorLockMode.None;
		//Screen.lockCursor = false;
		Cursor.visible = true;
 
		//enable pause menu
		enablePauseMenu ();
	}

	public void UnpauseGame()
	{
		isPaused = false;
		Time.timeScale = 1;
		//enable fps controls
		player.transform.GetComponent<MouseLook> ().enabled = true;
		Camera.main.GetComponent<MouseLook> ().enabled = true;

		//hide cursor
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		//Screen.lockCursor = true;

		//disable pause menu
		disablePauseMenu ();
	}

	public void enablePauseMenu()
	{
		pauseMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
		//pauseMenuPanel.GetComponent<RectTransform> ().position = new Vector3 (transform.position.x, 302, transform.position.z);
	}

	public void disablePauseMenu()
	{
		pauseMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, Screen.height * 2);
		//pauseMenuPanel.GetComponent<RectTransform> ().position = new Vector3 (transform.position.x, 1000, transform.position.z);
	}

	public void enableControlsMenu()
	{
		disableHelpMenu ();
		disablePauseMenu ();
		controlsMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
	}

	public void disableControlsMenu()
	{
		enableHelpMenu ();
		controlsMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, Screen.height * 2);
	}

	public void enableHelpMenu()
	{
		disablePauseMenu ();
		helpMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
	}
	
	public void disableHelpMenu()
	{
		enablePauseMenu ();
		helpMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, Screen.height * 2);
	}

	public void enableHintsMenu()
	{
		disableHelpMenu ();
		disablePauseMenu ();
		hintsMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
	}
	
	public void disableHintsMenu()
	{
		enableHelpMenu ();
		hintsMenuPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, Screen.height * 2);
	}

	public void QuitGame()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}
