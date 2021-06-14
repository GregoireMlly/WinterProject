using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Champ_select : MonoBehaviour
{
    public /*static*/ string currentPlayer;
    
    public string name;
    // Start is called before the first frame update
    public void loadlvl()
    {
        currentPlayer = name;
        SceneManager.LoadScene(1);
    }
}
