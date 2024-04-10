using Revity.DecaClimb.Persistant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Revity.DecaClimb
{
    public class CoinManager
    {

        private int m_CurrentCoin;
        public int CurrentCoin { get { return m_CurrentCoin; } }  

        
        public CoinManager() 
        {
            m_CurrentCoin = 0;
        }

        public void LevelUpCoin(int amount)
        {
            m_CurrentCoin += amount;
        }

        public void IncreaseCoin(int amount)
        {
            m_CurrentCoin += amount;
        }

        public void SaveCoin()
        {
			PersistantServiceLocator.Instance.DataHandler.CoinData.SaveCoins(CurrentCoin);
        }
    }
}