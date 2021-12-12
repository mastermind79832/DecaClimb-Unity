using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreScript 
{
    
    private static int score;

    private static int highscore;



    public static void ResetScore()
    {
        score = 0;
    }

    public static void IncreaseScore(int Multiplier)
    {
        int levelScore;
        if(levelsHandle.GetCurrentLevel() >= 1)
            levelScore = levelsHandle.GetCurrentLevel();
        else
            levelScore = 1;


        score += levelScore * Multiplier;
        

    }
    
    public static void SetHighScore()
    {
        if(score > highscore)
        {   
            highscore = score;
            PlayerPrefs.SetInt("Highscore",highscore);
        }
    }

    public static int GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        return highscore; 
    }

    public static int GetScore()
    {
        return score;
    }


}
