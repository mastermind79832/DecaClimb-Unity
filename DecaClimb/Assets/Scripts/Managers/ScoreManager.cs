using Revity.DecaClimb.Persistant;
using Revity.Core;

namespace Revity.DecaClimb.Game
{
    public class ScoreManager
    {
        private int m_Score;
        public int Score { get { return m_Score; } }

        private int m_Highscore;
        public int Highscore {  get { return m_Highscore; } }

        private readonly GameManager m_GameManager;

        private int m_Multiplier;
        private readonly Timer m_Timer;

        public float m_MultiplierTime = 2;

        public ScoreManager(GameManager gameManager) 
        {
            m_GameManager = gameManager;
			m_Highscore = PersistantServiceLocator.Instance.DataHandler.HighscoreData.HighScore;
            m_Timer = new(m_MultiplierTime, ResetMultiplier);
            ResetScore();
		}

        public void OnGameStart()
        {
            m_Timer.Start();
        }

        public void ResetScore()
        {
            m_Score = 0;
            ResetMultiplier();
        }

        private void ResetMultiplier()
        {
            m_Multiplier = 0;
        }

        public void IncreaseScore()
        {
            int levelScore;
            if (m_GameManager.LevelManager.CurrentLevel >= 1)
                levelScore = m_GameManager.LevelManager.CurrentLevel;
            else
                levelScore = 1;

            m_Score += levelScore * (++m_Multiplier);
            m_Timer.Restart();
        }

        public void SetHighscore()
        {
            m_Highscore = Score;
        }

        public void SaveHighscore()
        {
			PersistantServiceLocator.Instance.DataHandler.HighscoreData.SaveHighscore(Highscore);
        }
    }
}