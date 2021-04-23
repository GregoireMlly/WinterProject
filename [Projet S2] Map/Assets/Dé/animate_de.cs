using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics;
using System.Runtime;


public class animate_de : MonoBehaviour
{
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    public Material Material5;
    public Material Material6;
    //int milliseconds = 1000;
    public void Start()
    {
        GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
    }
    
    public void setImageToNext()
    {
        StartCoroutine(WaitBeforeNext());
    }

    IEnumerator WaitBeforeNext()
    {
        float temps = 0.17F;
        //Random Rnd = new Random();
        int x = 0;
        int n = Random.Range(1, 7); // normalement c'est 7 le bon
        while (x<3)
        {
            GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
            yield return new WaitForSeconds(temps);
            GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material2);
            yield return new WaitForSeconds(temps);
            GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material3);
            yield return new WaitForSeconds(temps);
            GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material4);
            yield return new WaitForSeconds(temps);
            GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material5);
            yield return new WaitForSeconds(temps);
            GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material6);
            x += 1;
        }
        yield return new WaitForSeconds(temps);
        switch (n) // va jusqua la valeur du dé
        {
            case 1:
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
                break;
            case 2:
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material2);
                
                break;
            case 3:
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material2);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material3);
                break;
            case 4:
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material2);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material3);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material4);
                break;
            case 5:
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material2);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material3);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material4);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material5);
                break;
            case 6:
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material1);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material2);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material3);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material4);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material5);
                yield return new WaitForSeconds(temps);
                GetComponent<Renderer> ().material.CopyPropertiesFromMaterial(Material6);
                break;
        }
    }
   
}

