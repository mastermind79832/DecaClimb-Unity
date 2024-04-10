using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int m_Value;
        public int Valve { get { return m_Value; } }
    }
}
