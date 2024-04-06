using Revity.Ads;
using Revity.DecaClimb.Persistant;
using UnityEngine;

namespace Revity.DecaClimb.Game
{

    /// <summary>
    /// Hnadles the logic in the gameplay.
    /// </summary>
    public class GameManager : MonoBehaviour
    {

        public GameObject gameOverPanel;

        public GameObject PausePanel;

        public GameObject pillar;


		void Start()
        {
            // Application.targetFrameRate = 60;
            gameOverPanel.SetActive(false);
            PausePanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            PauseMenu();
        }

        public void PauseMenu()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (gameOverPanel.activeSelf)
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
            ScoreScript.SetHighScore();

            gameOverPanel.SetActive(true);
            pillar.GetComponent<PillarController>().enabled = false;
        }

        public void GameFinish()
        {
            levelsHandle.IncreaseLevel();
            ScoreScript.SetHighScore();
            CoinsManagerScript.LevelUpCoin(levelsHandle.GetCurrentLevel() * 10);
			PersistantServiceLocator.Instance.SceneService.LoadGameScene();
		}

        public void MainMenu()
        {
            AdsManager.Instance.InterstitialAds.ShowAd();

            levelsHandle.SaveCheckPoint();
            Time.timeScale = 1;
            ScoreScript.ResetScore();
            CoinsManagerScript.CoinUpdate();
            PersistantServiceLocator.Instance.SceneService.LoadMainMenuScene();
        }

        public void RetryButton()
		{
            AdsManager.Instance.RewardAds.OnAdsShowCompleted = GetRetryReward;
			AdsManager.Instance.RewardAds.ShowAd();
		}

		public void GetRetryReward()
		{
			gameOverPanel.SetActive(false);
			//ScoreScript.ResetScore();
			//levelsHandle.ResetLevel();
			levelsHandle.isLevelUp = false;
			levelsHandle.isRetryUsed = true;
			PersistantServiceLocator.Instance.SceneService.LoadGameScene();

		}
	}
}