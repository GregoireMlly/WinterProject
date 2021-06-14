using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Donotdestroy : MonoBehaviour
{
    public Audio_manager audio_Manager;
    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (audio_Manager.playlist.Length == 1 && scene.buildIndex!=1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
