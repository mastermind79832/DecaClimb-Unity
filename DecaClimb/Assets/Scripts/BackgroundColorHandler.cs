using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecaClimb
{
    public class BackgroundColorHandler : MonoSingletonGeneric<BackgroundColorHandler>
    { 
        public Color[] colours;

		protected override void Awake()
		{
			base.Awake();
            DontDestroyOnLoad(gameObject);
		}

		public Color GetColorRandom()
        {
            int index  =  Random.Range(0,colours.Length);
            return colours[index];
        }

    }
}
