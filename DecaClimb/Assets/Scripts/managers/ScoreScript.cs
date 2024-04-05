using Revity.DecaClimb.Persistant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb
{
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
            if (levelsHandle.GetCurrentLevel() >= 1)
                levelScore = levelsHandle.GetCurrentLevel();
            else
                levelScore = 1;

            score += levelScore * Multiplier;

        }

        public static void SetHighScore()
        {
			PersistantServiceLocator.Instance.DataHandler.HighscoreData.SaveHighscore(score);
        }

        public static int GetHighscore()
        {
            highscore = PersistantServiceLocator.Instance.DataHandler.HighscoreData.HighScore;
            return highscore;
        }

        public static int GetScore()
        {
            return score;
        }


    }
}