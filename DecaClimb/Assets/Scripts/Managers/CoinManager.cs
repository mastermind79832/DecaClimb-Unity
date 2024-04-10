using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Revity.DecaClimb
{
    public class CoinManager
    {

        private int coin;

        public int GetCoin()
        {
            coin = PlayerPrefs.GetInt("Coins");
            return coin;
        }

        public int GetCurrentCoin()
        {
            return coin;
        }

        public void LevelUpCoin(int amount)
        {
            coin += amount;
        }

        public void IncreaseCoin(int amount)
        {
            coin += amount;
        }

        public void CoinUpdate()
        {
            PlayerPrefs.SetInt("Coins", coin);
        }
    }
}