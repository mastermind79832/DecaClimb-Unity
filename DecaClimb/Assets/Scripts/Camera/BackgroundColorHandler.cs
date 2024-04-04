using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Revity.Core;

namespace Revity.DecaClimb
{
    public class BackgroundColorHandler : MonoSingletonGeneric<BackgroundColorHandler>
    { 
        [SerializeField] private Color[] colours;

		public Color GetColorRandom()
        {
            int index  =  Random.Range(0,colours.Length);
            return colours[index];
        }

    }
}
