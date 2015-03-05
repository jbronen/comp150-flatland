using UnityEngine;
using System.Collections;

public class SFXLibrary : MonoBehaviour {
	
	public AudioClip pickup;
	public AudioClip drop;
	AudioListener listener;
	AudioSource source;

	// Use this for initialization
	void Start () {
		listener = GameObject.FindWithTag ("MainCamera").GetComponent<AudioListener> ();
		source = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play_pickup() {
		source.PlayOneShot (pickup);
	}

	public void play_drop () {
		source.PlayOneShot (drop);
	}
}
