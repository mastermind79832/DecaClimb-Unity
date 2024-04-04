using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Revity.DecaClimb
{
    public static class CoinsManagerScript
    {

        private static int coin;

        public static int GetCoin()
        {
            coin = PlayerPrefs.GetInt("Coins");
            return coin;
        }

        public static int GetCurrentCoin()
        {
            return coin;
        }

        public static void LevelUpCoin(int amount)
        {
            coin += amount;
        }

        public static void IncreaseCoin(int amount)
        {
            coin += amount;
        }

        public static void CoinUpdate()
        {
            PlayerPrefs.SetInt("Coins", coin);
        }
    }
}