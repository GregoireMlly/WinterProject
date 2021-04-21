using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate_de : MonoBehaviour
{
    public Material nMaterial;
    public void setImageToNext()   
    {
        nMaterial.SetColor("_Color", Color.black);
    }
}
