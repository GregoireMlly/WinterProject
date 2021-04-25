using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int MusiqueIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    void PlayNextSong()
    {
        if (playlist.Length != 1)
        {
            MusiqueIndex = (MusiqueIndex + 1) / playlist.Length;
        }

        audioSource.clip = playlist[MusiqueIndex];
        audioSource.Play();
    }
}
