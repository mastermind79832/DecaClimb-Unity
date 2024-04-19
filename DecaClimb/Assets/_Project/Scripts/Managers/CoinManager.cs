using Revity.DecaClimb.Persistant;
using System;


namespace Revity.DecaClimb
{
    public class CoinManager
    {

        private int m_CurrentCoin;
        public int CurrentCoin { get { return m_CurrentCoin; } }  

        public event Action<int> OnCoinChange;
        
        public CoinManager() 
        {
			m_CurrentCoin = 0;
        }

        public void IncreaseCoin(int amount)
		{
            SetCoin(CurrentCoin + amount);
		}

		private void SetCoin(int amount)
		{
			m_CurrentCoin = amount;
			OnCoinChange?.Invoke(CurrentCoin);
		}

		public void SaveCoin()
        {
			PersistantServiceLocator.Instance.DataHandler.CoinData.SaveCoins(CurrentCoin);
        }

		public void StartGame()
		{
			SetCoin(CurrentCoin);
		}
	}
}