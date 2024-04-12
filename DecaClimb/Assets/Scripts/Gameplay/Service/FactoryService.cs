using Revity.DecaClimb.Core;
using UnityEngine;

namespace Revity.DecaClimb.Game
{
    /// <summary>
    /// script that handles all the creation and it's initialization
    /// </summary>
    public class FactoryService
    {
        // Spawn/ Pool pillar
        private readonly ObjectPool<Pillar> m_PillarPool;
        private readonly ObjectPool<Coin> m_CoinPool;
		private readonly FactoryDataSO m_FactoryDataSO;

		public FactoryService(FactoryDataSO factoryDataSO)
        {
			m_FactoryDataSO = factoryDataSO;
            m_FactoryDataSO.PillarPrefab.gameObject.SetActive(false);
            m_FactoryDataSO.CoinPrefab.gameObject.SetActive(false);

            m_PillarPool = new(CreatePillar,5);
            m_CoinPool = new ObjectPool<Coin>(CreateCoin,5);
        }

        private Pillar CreatePillar() => Object.Instantiate(m_FactoryDataSO.PillarPrefab);
        private Coin CreateCoin() => Object.Instantiate(m_FactoryDataSO.CoinPrefab);

        public Material GetGround(GroundType type) => m_FactoryDataSO.GroundTypeSO.GetGroundTypeMaterial(type).Material;
        public Pillar GetPillar() => m_PillarPool.GetItem();
        public Coin GetCoin() => m_CoinPool.GetItem();

        public void NewLevel()
        {
            m_PillarPool.PoolAll();
            m_CoinPool.PoolAll();
        }

	}
}
