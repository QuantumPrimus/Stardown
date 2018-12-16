using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {
	private AudioSource source;
	public List<AudioClip> songs;
	public float vol = 0.3f;
	// [SerializeField]
	private float timer;
	private bool nextSongPlayed = false;
	private int i = 0;
	public CreditsSong cs;

	void Start () {
		source = GetComponent<AudioSource>();
		source.PlayOneShot(songs[i], vol);
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		// Debug.Log(timer);
		if (timer >= songs[i].length)
		{
			playNextSong();
		}
		
	}



	void playNextSong()
	{
		timer = 0;
		// nextSongPlayed = true;
		source.Stop();
		Debug.Log("Playing next song");
		i++;
		source.PlayOneShot(songs[i], vol);
		Debug.Log(songs[i]);
		cs.songName(i);
	}
}
