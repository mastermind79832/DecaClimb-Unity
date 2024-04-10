using Revity.Ads;
using Revity.DecaClimb.Persistant;
using System;
using UnityEngine;

namespace Revity.DecaClimb.Game
{

    /// <summary>
    /// Hnadles the logic in the gameplay.
    /// </summary>
    public class GameManager : MonoBehaviour
    {

        //public GameObject gameOverPanel;

        private GameOverUI m_GameOverUI;
        private LevelManager m_LevelManager;
        public LevelManager LevelManager { get { return m_LevelManager; } }

        public GameObject PausePanel;

        public GameObject pillar;

        private bool m_IsRetryPossible;

		void Start()
        {
            m_IsRetryPossible = true;
            // Application.targetFrameRate = 60;
            //gameOverPanel.SetActive(false);
            PausePanel.SetActive(false);
        }

        public void Initialize()
        {
            m_GameOverUI = GameSceneService.Instance.UIManager.GameOverUI;
            m_GameOverUI.Initialize(RetryButton,MainMenu);

            m_LevelManager = new();
        }

        // Update is called once per frame
        void Update()
        {
            EscapeInput();
        }

        public void EscapeInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (m_GameOverUI.IsActive)   
                {
                    MainMenu();
                    return;
                }

                if (PausePanel.activeSelf)
                {
                    ContinueGame();
                    return;
                }
                Time.timeScale = 0;
                pillar.GetComponent<PillarController>().enabled = false;
                PausePanel.SetActive(true);
            }
        }

        public void ContinueGame()
        {
            pillar.GetComponent<PillarController>().enabled = true;
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void GameOver()
        {
            ScoreManager.SetHighScore();

            // gameOverPanel.SetActive(true);
            // set highscore
            m_GameOverUI.ShowGameOverUI(m_IsRetryPossible, 0);
            pillar.GetComponent<PillarController>().enabled = false;
        }

        public void GameFinish()
        {
            LevelManager.IncreaseLevel();
            ScoreManager.SetHighScore();
            CoinManager.LevelUpCoin(LevelManager.GetCurrentLevel() * 10);
            GameSceneService.Instance.RefreshLevel();
			//PersistantServiceLocator.Instance.SceneService.LoadGameScene();
		}

        public void MainMenu()
        {
            AdsManager.Instance.InterstitialAds.ShowAd();

            LevelManager.SaveCheckPoint();
            Time.timeScale = 1;
            ScoreManager.ResetScore();
            CoinManager.CoinUpdate();
            PersistantServiceLocator.Instance.SceneService.LoadMainMenuScene();
        }

        public void RetryButton()
		{
            AdsManager.Instance.RewardAds.OnAdsShowCompleted = GetRetryReward;
			AdsManager.Instance.RewardAds.ShowAd();
		}

		public void GetRetryReward()
		{
            //gameOverPanel.SetActive(false);
            //ScoreScript.ResetScore();
            //levelsHandle.ResetLevel();
            m_IsRetryPossible = false;
			LevelManager.isLevelUp = false;
			LevelManager.isRetryUsed = true;
			GameSceneService.Instance.RefreshLevel();
			//PersistantServiceLocator.Instance.SceneService.LoadGameScene();

		}
	}
}