using Revity.Ads;
using Revity.DecaClimb.Game.UI;
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
        private PauseUI m_PauseUI;
        
        private bool m_IsRetryPossible;

        public PillarController m_PillarController;

        public void Initialize()
        {
            m_IsRetryPossible = true;
            m_GameOverUI = GameSceneService.Instance.UIManager.GameOverUI;
            m_PauseUI = GameSceneService.Instance.UIManager.PauseUI;

            m_GameOverUI.Initialize(RetryButton,MainMenu);
            m_PauseUI.Initialize(GameOver,ContinueGame);
        }
        // Update is called once per frame
        void Update()
        {
            EscapeInput();
        }

        private void EscapeInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (m_GameOverUI.IsActive)   
                {
                    MainMenu();
                    return;
                }

                if (m_PauseUI.IsActive)
                {
                    ContinueGame();
                    return;
                }
                Time.timeScale = 0;
                m_PillarController.enabled = false;
                m_PauseUI.ShowPauseUI();
            }
        }

        /// <summary>
        /// resume the game After Pause
        /// </summary>
        public void ContinueGame()
        {
            m_PillarController.enabled = true;
            m_PauseUI.DisableUI();
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
            m_PillarController.enabled = false;
        }

        /// <summary>
        /// Called when the player reaches the finish line
        /// </summary>
        public void GameFinish()
        {
            GameSceneService.Instance.LevelManager.IncreaseLevel();
			GameSceneService.Instance.ScoreManager.SetHighscore();
			GameSceneService.Instance.CoinManager.IncreaseCoin(GameSceneService.Instance.LevelManager.CurrentLevel * 10);
            GameSceneService.Instance.NextLevel();
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
			GameSceneService.Instance.ScoreManager.SaveHighscore();
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
			Time.timeScale = 1;
			m_PillarController.enabled = true;
			m_IsRetryPossible = false;
			GameSceneService.Instance.NextLevel();

		}

	}
}