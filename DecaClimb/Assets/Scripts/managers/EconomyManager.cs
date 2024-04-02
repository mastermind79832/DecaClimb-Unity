using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecaClimb
{
    public class EconomyManager : MonoBehaviour
    {
		private const string STR_COINS = "Coins";

		[SerializeField] private int m_Coins;
		public int Coins { get { return m_Coins; } }

		public void GetDataFromMemeory()
		{
			m_Coins = 0;
			m_Coins = PlayerPrefs.GetInt(STR_COINS);
		}

		public void SetCoins(int coins)
		{
			m_Coins += coins;
			PlayerPrefs.SetInt(STR_COINS, m_Coins);
		}

		public void NewInstall()
		{
			SetCoins(0);
		}

		public void ReturningUser()
		{
			GetDataFromMemeory();
		}
	}
}
