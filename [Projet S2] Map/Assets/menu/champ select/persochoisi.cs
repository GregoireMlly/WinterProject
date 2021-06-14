using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class persochoisi : MonoBehaviour
{
    public Transform[] playerList;
    public Transform CurrentPlayer;
    public Champ_select champ_select;
    // Start is called before the first frame update
    void Start()
    {
        if(champ_select.currentPlayer!=null)
        {
            CurrentPlayer = playerList.Single(d => d.name == champ_select.currentPlayer);
            if(CurrentPlayer==null)
            {
                SceneManager.LoadScene(0);
            }
            InstantiatePlayer();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void InstantiatePlayer()
    {
        if (CurrentPlayer!=null)
        {
            CurrentPlayer = Instantiate(CurrentPlayer, transform.position, CurrentPlayer.rotation) as Transform;
            CurrentPlayer.parent = transform;
        }
    }
}
