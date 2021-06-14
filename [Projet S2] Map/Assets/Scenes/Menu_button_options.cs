using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_button_options : MonoBehaviour
{
    
   
    //AudioSource m_MyAudioSource;
     //volume
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    //void Start()
   // {
        
        //m_MyAudioSource = GetComponent<AudioSource>();
   // }
    
    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Escape) && scene.buildIndex>1)
        {
            switch(scene.buildIndex)
            {
                case 3:
                    SceneManager.LoadScene(0);
                    break;
            }
            //SceneManager.LoadScene(scene.buildIndex - 1);
        }
       // m_MyAudioSource.volume = m_MySliderValue;

    }
    public void options_to_menu()
    {
        SceneManager.LoadScene(0);
    }
    public void to_champ_select()
    {
        SceneManager.LoadScene(4);
    }
    public void play_to_single_mutli()
    {
        SceneManager.LoadScene(3);
    }
   
    public void option_button()
    {
        SceneManager.LoadScene(2);
    }
    public void fullscreen_button()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void quit_button()
    {
        Application.Quit();
    }
}
