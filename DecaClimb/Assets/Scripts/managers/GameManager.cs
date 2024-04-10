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

        // Reference
        private GameOverUI m_GameOverUI;
        
        private bool m_IsRetryPossible;

        public GameObject PausePanel;
        public GameObject pillar;

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

        /// <summary>
        /// resume the game After Pause
        /// </summary>
        public void ContinueGame()
        {
            pillar.GetComponent<PillarController>().enabled = true;
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        /// <summary>
        /// Call when the player loses
        /// </summary>
        public void GameOver()
        {
            GameSceneService.Instance.ScoreManager.SetHighscore();

            // gameOverPanel.SetActive(true);
            // set highscore
            m_GameOverUI.ShowGameOverUI(m_IsRetryPossible, 0);
            pillar.GetComponent<PillarController>().enabled = false;
        }

        /// <summary>
        /// Called when the player reaches the finish line
        /// </summary>
        public void GameFinish()
        {
            GameSceneService.Instance.LevelManager.IncreaseLevel();
			GameSceneService.Instance.ScoreManager.SetHighscore();
			GameSceneService.Instance.CoinManager.LevelUpCoin(GameSceneService.Instance.LevelManager.CurrentLevel * 10);
            GameSceneService.Instance.RefreshLevel();
			//PersistantServiceLocator.Instance.SceneService.LoadGameScene();
		}

        /// <summary>
        /// Game goes back to the MainMenu
        /// </summary>
        public void MainMenu()
        {
            AdsManager.Instance.InterstitialAds.ShowAd();

			GameSceneService.Instance.LevelManager.SaveCheckPoint();
            Time.timeScale = 1;
			GameSceneService.Instance.ScoreManager.ResetScore();
			GameSceneService.Instance.CoinManager.SaveCoin();
            PersistantServiceLocator.Instance.SceneService.LoadMainMenuScene();
        }

        /// <summary>
        /// Called by the Game Over UI.
        /// Lets you retry the game by watching ads
        /// </summary>
        public void RetryButton()
		{
            AdsManager.Instance.RewardAds.OnAdsShowCompleted = GetRetryReward;
			AdsManager.Instance.RewardAds.ShowAd();
		}

		public void GetRetryReward()
		{
            m_IsRetryPossible = false;
			GameSceneService.Instance.RefreshLevel();

		}
	}
}