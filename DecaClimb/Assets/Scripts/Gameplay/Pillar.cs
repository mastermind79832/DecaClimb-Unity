using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb
{
    public class Pillar : MonoBehaviour
    {
        [SerializeField] private Ground[] m_Grounds;

        public void SetGround(int[] groundData)
        {
            for (int i = 0; i < m_Grounds.Length; i++)
            {
                if (groundData[i] == 3)
                    m_Grounds[i].gameObject.SetActive(false);
                else
                {
                    m_Grounds[i].SetGroundType((GroundType)groundData[i]);
                    m_Grounds[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
