using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Revity.DecaClimb
{
    public class GroundManager : MonoBehaviour
    {
        private const int MAX_GROUND_COUNT = 10;

        private bool m_IsFirstPillar = false;
        private bool m_IsLastPillar = false;

        public GroundType[] m_GroundData;
        [SerializeField] private Pillar m_Pillar;

		public void Initialize(bool isFirstPillar, bool isLastPillar)
		{
            m_IsFirstPillar = isFirstPillar;
            m_IsLastPillar = isLastPillar;
			m_GroundData = new GroundType[10];

			GroundSpwan();
			GroundDestroy();
			SetDangerZone();

			m_Pillar.SetGround(m_GroundData);
		}

		private void GroundSpwan()
        {
            for (int i = 0; i < MAX_GROUND_COUNT; i++)
            {
                m_GroundData[i] = 0;

                if (m_IsLastPillar)
                {
                    m_GroundData[i] = GroundType.Goal;
                }
            }
        }

        private void GroundDestroy()
		{

            int amountToDestroy = GetRandom(2, 6);

			for (int i = 0; i < amountToDestroy; i++)
			{
				int index = GetRandomIndex();
				m_GroundData[index] = GroundType.Empty;
				// Destroy(transform.GetChild(index).gameObject);
			}
		}

		private int GetRandomIndex()
		{
			/* first and last ground or first pillar should alwasy be normal
			 * for initial player foothold 
			*/
			return GetRandom(m_IsFirstPillar ? 1 : 0, m_IsFirstPillar ? 9 : MAX_GROUND_COUNT);
		}

		private void SetDangerZone()
		{
			if (m_IsLastPillar) return;

			int normalCount = GetNormalGroundCount();
			/* atleast one danger ground 
			 * atleast one normal ground
			 */
			int dangerZone = GetRandom(1, normalCount);

			for (int i = 0; i < dangerZone; i++)
			{
				int index = GetRandomIndex();

				//Empty grounds should not be changed to make sure we have proper hoes
				if (m_GroundData[index] == GroundType.Empty)
				{
					i--;
					continue;
				}
				m_GroundData[index] = GroundType.Danger;

			}
		}

		private int GetNormalGroundCount()
		{
			return Array.FindAll(m_GroundData, i => i == GroundType.Normal).Length;
		}

		private int GetRandom(int min, int max)
		{
			return Random.Range(min, max);
		}

    }
}