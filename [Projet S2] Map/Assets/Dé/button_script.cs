using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class button_script : MonoBehaviour
{
    //Material m_Material;
    public UnityEvent ButtonClick;
    void Start()
    {
       // m_Material = GetComponent<Renderer>().material;
    }
    void Awake()
    {
        if (ButtonClick==null)
        {
            ButtonClick = new UnityEvent();
        }
    }
   void OnMouseUp()
    {
        //m_Material = SetTexture;
        int dé_roll = Random.Range(1, 7);
        
    }
}
