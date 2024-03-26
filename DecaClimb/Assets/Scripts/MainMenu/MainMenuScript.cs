using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour
{
    public GameObject statPanel;
    public Text highScoreText;
    public Text checkPointText;
    public Text coinText;

    public GameObject instructionPanel;
    public GameObject cheatPanel;
    
    public InputField coinsCheat;
    public InputField levelCheat; 

    public Camera menuCamera;
    public GameObject colorMat;

    private void Start()
    {
       // Application.targetFrameRate = 60;
        statPanel.SetActive(false);
        cheatPanel.SetActive(false);
        instructionPanel.SetActive(false);
        highScoreText.text = ScoreScript.GetHighscore().ToString();
       
        checkPointText.text = levelsHandle.GetCheckpoint().ToString();

        coinText.text = CoinsManagerScript.GetCoin().ToString();

        menuCamera.backgroundColor = colorMat.GetComponent<ColorMatScript>().GetColorRandom();

    }
    

    private void Update()
    {
        if( Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        // if(instructionPanel.activeSelf && Input.GetMouseButtonDown(0))
        // {
        //     instructionPanel.SetActive(false);
        // }

    }

    public void GameStart()
    {
        levelsHandle.ResetLevel();
        levelsHandle.isLevelUp = false;
        levelsHandle.isRetryUsed = false;
        SceneManager.LoadScene(2);    
    }

    public void Instuction()
    {
        if(instructionPanel.activeSelf)
            instructionPanel.SetActive(false);
        else
            instructionPanel.SetActive(true);
        cheatPanel.SetActive(false);
    }


    public void Stats()
    {
        if(statPanel.activeSelf)
            statPanel.SetActive(false);
        else
            statPanel.SetActive(true);
    }

    public void Cheats()
    {
        if(cheatPanel.activeSelf)
            cheatPanel.SetActive(false);
        else
            cheatPanel.SetActive(true);
    }

    public void SetCheat()
    {
        // int coin = int.Parse(coinsCheat.text);
        // int level =  int.Parse(levelCheat.text);
     
        if(coinsCheat.text != "")
        {
            int coin = System.Convert.ToInt32(coinsCheat.text);
            PlayerPrefs.SetInt("Coins", coin);
            coinText.text = CoinsManagerScript.GetCoin().ToString();
        }


        if(levelCheat.text != "")
        {
            int level =  System.Convert.ToInt32(levelCheat.text);
            PlayerPrefs.SetInt("CheckPoint", level);
            checkPointText.text = levelsHandle.GetCheckpoint().ToString();
        }
    }

    public void UpgradePage()
    {
        SceneManager.LoadScene(3);
    }
}
