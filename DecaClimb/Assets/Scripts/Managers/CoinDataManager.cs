using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb.Persistant
{
    public class CoinDataManager
    {
		private const string STR_COINS = "Coins";

		[SerializeField] private int m_Coins;
		public int Coins { get { return m_Coins; } }

		public event Action<int> OnCoinsChanged;

		public void SaveCoins(int coins)
		{
			PlayerPrefs.SetInt(STR_COINS, coins);
			m_Coins = coins;
			OnCoinsChanged?.Invoke(coins);
		}

		public void NewInstall()
		{
			SaveCoins(0);
		}

		public void Initialize()
		{
			m_Coins = PlayerPrefs.GetInt(STR_COINS);
		}
	}
}
