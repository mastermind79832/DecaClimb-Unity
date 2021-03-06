using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
         if(Input.GetKeyDown(KeyCode.Escape))
        {

            if(gameOverPanel.activeSelf)
            {
                MainMenu();
                return;
            }


            if(PausePanel.activeSelf)
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
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        levelsHandle.SaveCheckPoint();
        Time.timeScale = 1;
        ScoreScript.ResetScore();
        CoinsManagerScript.CoinUpdate();
        SceneManager.LoadScene(1);
    }


    public void RetryButton()
    {
        gameOverPanel.SetActive(false);
        //ScoreScript.ResetScore();
        //levelsHandle.ResetLevel();
        levelsHandle.isLevelUp = false;
        levelsHandle.isRetryUsed = true;
        SceneManager.LoadScene(2);
    }




}
