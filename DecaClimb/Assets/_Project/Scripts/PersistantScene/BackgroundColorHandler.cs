using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Revity.Core;

namespace Revity.DecaClimb
{

	public class BackgroundColorHandler
    { 
        [SerializeField] private Color[] m_Colors;

        public BackgroundColorHandler(BackgroundColorHandlerSO colorSO)
		{
			m_Colors = colorSO.Colors;
		}

		public Color GetColorRandom()
        {
            int index  =  Random.Range(0,m_Colors.Length);
            return m_Colors[index];
        }

    }
}
