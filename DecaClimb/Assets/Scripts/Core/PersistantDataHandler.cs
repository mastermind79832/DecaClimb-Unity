using System;
using System.Diagnostics.Tracing;
using UnityEngine;

namespace DecaClimb
{
    public class PersistantDataHandler : MonoSingletonGeneric<PersistantDataHandler>
    {
        private const string STR_VERSION = "Version";
        private const string STR_HIGHSCORE = "Highscore";
        private const string STR_COINS = "Coins";
        private const string STR_CHECKPOINT = "CheckPoint";

		[SerializeField] private int m_HighScore;
        public int HighScore { get { return m_HighScore; }  }
        public Action<int> OnNewHighScoreSet { get; set; }

        [SerializeField] private int m_AquiredCoins;
        public int AquiredCoins { get { return m_AquiredCoins; } }

        [SerializeField] private int m_CheckPoint;
        public int Checkpoint {  get { return m_CheckPoint; } }

        private float CurrentVersion { get { return float.Parse(Application.version); } }

		override protected void Awake()
		{
            base.Awake();
            m_HighScore = 0;
            m_AquiredCoins = 0;
			SetDataFromMemeory();
		}

		public void SetDataFromMemeory()
        {
            // First Time playing
            if (!PlayerPrefs.HasKey(STR_VERSION))
            {
                PlayerPrefs.SetFloat(STR_VERSION, CurrentVersion);
                SetCoins(0);
                SetHighscore(0);
                SetCheckPoint(0);
            }
            // New version / updated
            else if (PlayerPrefs.GetFloat(STR_VERSION) < CurrentVersion)
            {
				// show change log or something
				PlayerPrefs.SetFloat(STR_VERSION, CurrentVersion);
			}

            m_AquiredCoins = PlayerPrefs.GetInt(STR_COINS);
            m_HighScore = PlayerPrefs.GetInt(STR_HIGHSCORE);
            m_CheckPoint = PlayerPrefs.GetInt(STR_CHECKPOINT);
        }

        public void SetCoins(int coins)
        {
            m_AquiredCoins += coins;
            PlayerPrefs.SetInt(STR_COINS, m_AquiredCoins);
		}

        public void SetHighscore(int score)
        {
            if (m_HighScore <= score)
            {
                m_HighScore = score;
                OnNewHighScoreSet?.Invoke(m_HighScore);
            }

            PlayerPrefs.SetInt(STR_HIGHSCORE, m_HighScore);
        }

        public void SetCheckPoint(int checkPoint)
        {
            m_CheckPoint = checkPoint;
            PlayerPrefs.SetInt(STR_CHECKPOINT, m_CheckPoint);
        }
    }
}
