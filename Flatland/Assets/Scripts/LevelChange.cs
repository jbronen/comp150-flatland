using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

	// Use this for initialization
	public string SceneName;
	public float tSize = 0.2f,rate = 0.04f;
	public bool transistioning;
	public int tX,tY,tZ;
	public int transTime;
	//float moveR = 0.1f;
	//int tTime;
	Transform player;
	private GameController gameController;
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	// Update is called once per frame
	void Update () {
	}
	void FixedUpdate()
	{
		if(transistioning)
		{
			player.GetComponent<SphereCollider>().enabled = false;
			player.localScale = new Vector3(3,3,3);
			Application.LoadLevel(SceneName);
			transistioning = false;
			//player.GetComponent<CharacterControls>().transistioning = false;
			player.GetComponent<SphereCollider>().enabled = true;
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (gameController.solved()) {
			if (col.transform.tag == "Player" && !col.isTrigger) {
				player = col.transform;
				transistioning = true;
				//tTime = transTime;
				//player.GetComponent<CharacterControls>().transistioning = true;
			}
		}
	}
}
public class ApplicationModel {
	static public int door = 0; // this is reachable from everywhere
	static public bool fromDoor = false;
}
