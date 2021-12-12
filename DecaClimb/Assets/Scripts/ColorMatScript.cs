using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMatScript : MonoBehaviour
{
    


    public Color[] colours;

    public Color GetColorRandom()
    {
        int index  =  Random.Range(0,colours.Length);

        return colours[index];
    }


}
