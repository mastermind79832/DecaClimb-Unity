using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace Revity.DecaClimb
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
            currentScore = ScoreManager.GetScore();
            scoreText.text = currentScore.ToString();
            int level = LevelManager.GetCurrentLevel();
            levelText.text = level.ToString();

            LevelUp(level);
            RetryEnable();

        }

        private void RetryEnable()
        {
            if (LevelManager.isRetryUsed)
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

            if (LevelManager.isLevelUp)
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
            if (ScoreManager.GetScore() > currentScore)
            {
                int diff = ScoreManager.GetScore() - currentScore;
                StartCoroutine(ScoreIncrease(diff));
                scoreText.text = ScoreManager.GetScore().ToString();
                currentScore += diff;
            }
            hisghScoreText.text = "Highscore :" + ScoreManager.GetHighscore().ToString();

            coinText.text = CoinManager.GetCurrentCoin().ToString();

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