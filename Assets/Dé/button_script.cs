using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class button_script : MonoBehaviour
{
    public UnityEvent ButtonClick;
    void Awake()
    {
        if (ButtonClick==null)
        {
            ButtonClick = new UnityEvent();
        }
    }
   void OnMouseUp()
    {
        int dé_roll = Random.Range(1, 7);
    }
}
