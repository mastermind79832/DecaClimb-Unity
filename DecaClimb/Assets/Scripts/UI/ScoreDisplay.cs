using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace DecaClimb
{
    public class ScoreDisplay : MonoBehaviour
    {

        public Text hisghScoreText;
        public Text scoreText;

        public Text levelText;
        public GameObject levelUpText;

        public Text ScoreIncreaseText;

        public Text coinText;

        public Button retry;

        int currentScore;

        private void Start()
        {
            levelUpText.SetActive(false);
            currentScore = ScoreScript.GetScore();
            scoreText.text = currentScore.ToString();
            int level = levelsHandle.GetCurrentLevel();
            levelText.text = level.ToString();

            LevelUp(level);
            RetryEnable();

        }

        private void RetryEnable()
        {
            if (levelsHandle.isRetryUsed)
            {
                retry.interactable = false;
                GameObject videoImage = retry.transform.GetChild(0).gameObject;
                //videoImage.GetComponentInChildren<Image>().color = new Color(0f,0f,0f,20f);
                videoImage.SetActive(false);
            }
        }

        private void LevelUp(int level)
        {
            if (level % 5 == 0)
            {
                levelUpText.GetComponent<Text>().text = "CHECKPOINT";
            }
            else
            {
                levelUpText.GetComponent<Text>().text = "LEVELUP";
            }

            if (levelsHandle.isLevelUp)
            {
                StartCoroutine(ShowLevelUp());

            }
        }

        IEnumerator ShowLevelUp()
        {
            levelUpText.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            Destroy(levelUpText);
        }

        void FixedUpdate()
        {
            if (ScoreScript.GetScore() > currentScore)
            {
                int diff = ScoreScript.GetScore() - currentScore;
                StartCoroutine(ScoreIncrease(diff));
                scoreText.text = ScoreScript.GetScore().ToString();
                currentScore += diff;
            }
            hisghScoreText.text = "Highscore :" + ScoreScript.GetHighscore().ToString();

            coinText.text = CoinsManagerScript.GetCurrentCoin().ToString();

        }

        IEnumerator ScoreIncrease(int diff)
        {
            Text tempText = Instantiate(ScoreIncreaseText, scoreText.transform) as Text;

            tempText.text = "+" + diff.ToString();

            yield return new WaitForSeconds(2f);

            Destroy(tempText);

        }
    }
}