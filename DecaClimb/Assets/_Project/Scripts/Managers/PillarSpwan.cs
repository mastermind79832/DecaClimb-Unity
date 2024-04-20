using System.Collections.Generic;
using UnityEngine;


namespace Revity.DecaClimb.Game
{
    public class PillarSpwan : MonoBehaviour
    {
		private int m_MinPillarCount;
        private int m_MaxPillarCount;

        private List<Pillar> m_PillarList;

		private void Awake()
		{
			m_PillarList = new List<Pillar>();
		}

		public void NewLevel()
		{
            m_PillarList.Clear();
            transform.eulerAngles = Vector3.zero;
            Initialize();
		}

		public void Initialize()
		{
			SetPillarCountRange();
			SpwanPillars();
			SpawnCoins();
		}

		private void SetPillarCountRange()
		{
			int level = GameSceneService.Instance.LevelManager.CurrentLevel;
			if (level == 0)
			{
				m_MinPillarCount = 4;
				m_MaxPillarCount = 5;
			}
			else if (level > 10)
			{
				m_MinPillarCount = level;
				m_MaxPillarCount = level + 3;
			}
			else
			{
				m_MinPillarCount = 7;
				m_MaxPillarCount = 10;
			}
		}

		private void SpwanPillars()
        {
            int pillarAmount = Random.Range(m_MinPillarCount, m_MaxPillarCount);
			Pillar newPillar;

			for (int i = 0; i <= pillarAmount; i++)
            {
                newPillar = GameSceneService.Instance.FactoryService.GetPillar();
                newPillar.PillarLevel = i;
                newPillar.transform.parent = transform;
                newPillar.transform.eulerAngles = Vector3.zero;
                newPillar.transform.position = new Vector3(transform.position.x, i * 4, transform.position.z);

                newPillar.GetComponent<GroundManager>().Initialize(i == 0, i == pillarAmount);
                m_PillarList.Add(newPillar);
            }
		}

		private void SpawnCoins()
		{
			// every level needs atleast 2 coins 
			// -1 : exclude goal pillar
			int coinCount = Random.Range(2, m_PillarList.Count - 1); 

			for (int i = 0; i < coinCount; i++)
			{
				Coin coin = GameSceneService.Instance.FactoryService.GetCoin();

				int pillarIndex = Random.Range(0, m_PillarList.Count - 1); 
				coin.transform.parent = m_PillarList[pillarIndex].transform;
				
				// Don't spawn right in front of player spawn
				// player always spawn in 0th pillar with y rotation zero.
				coin.transform.SetPositionAndRotation(m_PillarList[pillarIndex].transform.position, Quaternion.Euler(0, Random.Range(pillarIndex == 0 ? 20 : 0, pillarIndex == 0 ? 330 : 360), 0));
			}
		}

	}
}