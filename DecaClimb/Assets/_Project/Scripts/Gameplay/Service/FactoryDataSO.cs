using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb.Game
{
    [CreateAssetMenu(fileName ="Factory Data", menuName = "DataSO/Factory")]
    public class FactoryDataSO : ScriptableObject
    {
        public Pillar PillarPrefab;
        public Coin CoinPrefab;
		public GroundTypeSO GroundTypeSO;

	}
}
