using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecaClimb
{
    public static class levelsHandle
    {


        private static int currentLevel;

        private static int checkPointLevel;

        public static bool isLevelUp;

        public static bool isRetryUsed;



        public static int GetCurrentLevel()
        {
            return currentLevel;
        }

        public static void ResetLevel()
        {
            currentLevel = checkPointLevel;
        }

        public static void IncreaseLevel()
        {
            currentLevel += 1;
            isLevelUp = true;
            if (currentLevel > checkPointLevel && currentLevel % 5 == 0)
                checkPointLevel = currentLevel;
        }

        public static int GetCheckpoint()
        {
            checkPointLevel = PlayerPrefs.GetInt("CheckPoint");
            return checkPointLevel;
        }

        public static void SaveCheckPoint()
        {
            PlayerPrefs.SetInt("CheckPoint", checkPointLevel);
        }

    }
}