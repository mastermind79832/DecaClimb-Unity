using Revity.Ads;
using Revity.DecaClimb.Persistant;
using System;

namespace Revity.DecaClimb.Game
{
    public class LevelManager
    {

        private int m_CurrentLevel;
        public int CurrentLevel {  get { return m_CurrentLevel; } } 

        private int m_Checkpoint;
        public int Checkpoint { get { return m_Checkpoint; } }

		public event Action<int> OnLevelChanged;

        public LevelManager() 
        {
			m_Checkpoint = PersistantServiceLocator.Instance.DataHandler.CheckpointData.Checkpoint;
			m_CurrentLevel = m_Checkpoint;
		}

        public int GetCurrentLevel()
        {
            return m_CurrentLevel;
        }

        public void ResetLevel()
        {
           // m_CurrentLevel = PersistantServiceLocator.Instance.DataHandler.CheckpointData.Checkpoint;
        }

        public void IncreaseLevel()
		{
			m_CurrentLevel += 1;
			OnLevelChanged?.Invoke(m_CurrentLevel);

			SetCheckPoint();
			ShowAds();
		}

		private void SetCheckPoint()
		{
			if (m_CurrentLevel > m_Checkpoint && m_CurrentLevel % 5 == 0)
				m_Checkpoint = m_CurrentLevel;
		}

		private void ShowAds()
		{
			if (m_CurrentLevel % 3 == 0)
			{
				AdsManager.Instance.InterstitialAds.ShowAd();
			}
		}

        public void SaveCheckPoint()
        {
			// Show rewarded ads to save checkpoint

			PersistantServiceLocator.Instance.DataHandler.CheckpointData.SaveCheckpoint(m_Checkpoint);
        }
    }
}