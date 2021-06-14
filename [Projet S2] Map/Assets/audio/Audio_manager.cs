using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    public AudioClip[] playlist;
    public GameObject ObjectMusic;
    private AudioSource audioSource;
    private int MusiqueIndex=0;
    float m_MySliderValue;
    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = playlist[0];
        //audioSource.Play();
        m_MySliderValue = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>(); // <- test ne fonctionnant pas
        audioSource.volume = m_MySliderValue;
        if(!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    
    public void updatevolume(float volume)
    {
        m_MySliderValue = volume;
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
    public void mute()
    {
        audioSource.mute = !audioSource.mute;
    }
}
