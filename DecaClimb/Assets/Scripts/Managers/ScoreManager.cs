using Revity.DecaClimb.Persistant;
using Revity.Core;
using System;

namespace Revity.DecaClimb.Game
{
    public class ScoreManager
    {
        private int m_Score;
        public int Score { get { return m_Score; } }

        private int m_Highscore;
        public int Highscore {  get { return m_Highscore; } }

        private int m_Multiplier;
        private readonly Timer m_Timer;

        public float m_MultiplierTime = 2;

        public event Action<int> OnScoreChanged;

        public ScoreManager() 
        {
			m_Highscore = PersistantServiceLocator.Instance.DataHandler.HighscoreData.HighScore;
            m_Score = 0;
            m_Timer = new(m_MultiplierTime, ResetMultiplier);
		}

        public void Update(float deltaTime)
        {
            m_Timer.Tick(deltaTime);
        }

        public void ResetScore()
        {
            SetScore(Score);
            ResetMultiplier();
        }

        private void ResetMultiplier()
        {
            m_Multiplier = 0;
        }

        public void IncreaseScore()
		{
			int levelScore;
			if (GameSceneService.Instance.LevelManager.CurrentLevel >= 1)
				levelScore = GameSceneService.Instance.LevelManager.CurrentLevel;
			else
				levelScore = 1;

			SetScore(Score + levelScore * (++m_Multiplier));
			m_Timer.Restart();
		}

		private void SetScore(int score)
		{
			m_Score = score;
			OnScoreChanged?.Invoke(m_Score);
		}

		public void SetHighscore()
        {
            m_Highscore = Score;
        }

        public void SaveHighscore()
        {
            if (m_Highscore > PersistantServiceLocator.Instance.DataHandler.HighscoreData.HighScore)
            {
			    PersistantServiceLocator.Instance.DataHandler.HighscoreData.SaveHighscore(Highscore);
            }
        }

		public void StartGame()
		{
			ResetScore();
			m_Timer.Start();
		}
	}
}