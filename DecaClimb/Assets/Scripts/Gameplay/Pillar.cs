using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb
{
    public class Pillar : MonoBehaviour
    {
        [SerializeField] private Ground[] m_Grounds;

        public void SetGround(GroundType[] groundData)
        {
            for (int i = 0; i < m_Grounds.Length; i++)
            {
                if (groundData[i] == GroundType.Empty)
                    m_Grounds[i].gameObject.SetActive(false);
                else
                {
                    m_Grounds[i].SetGroundType(groundData[i]);
                    m_Grounds[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
