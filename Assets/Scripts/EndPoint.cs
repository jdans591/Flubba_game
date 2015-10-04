using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

	public AudioClip[] audioClip;
	AudioSource audio;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			PlaySound (0);
		}
	}

	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.Play ();
	}
}
