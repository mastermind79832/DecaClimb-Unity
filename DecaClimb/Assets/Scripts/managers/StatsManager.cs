using System;
using UnityEngine;

namespace Revity.DecaClimb
{
	/// <summary>
	/// Handles the statistics of the player. Like score and checkpoint Level
	/// </summary>
    public class StatsManager : MonoBehaviour
    {
		private const string STR_HIGHSCORE = "Highscore";
		private const string STR_CHECKPOINT = "CheckPoint";

		[SerializeField] private int m_HighScore;
		public int HighScore { get { return m_HighScore; } }
		public event Action<int> OnNewHighScoreChanged;

		[SerializeField] private int m_CheckPoint;
		public int Checkpoint { get { return m_CheckPoint; } }

		public void GetDataFromMemeory()
		{
			m_HighScore = PlayerPrefs.GetInt(STR_HIGHSCORE);
			m_CheckPoint = PlayerPrefs.GetInt(STR_CHECKPOINT);
		}

		public void SetHighscore(int score)
		{
			if (m_HighScore <= score)
			{
				m_HighScore = score;
				OnNewHighScoreChanged?.Invoke(m_HighScore); // achievement/prompt
			}

			PlayerPrefs.SetInt(STR_HIGHSCORE, m_HighScore);
		}

		public void SetCheckPoint(int checkPoint)
		{
			m_CheckPoint = checkPoint;
			PlayerPrefs.SetInt(STR_CHECKPOINT, m_CheckPoint);
		}

		public void NewInstall()
		{
			SetCheckPoint(0);
			SetHighscore(0);
		}

		public void ReturningUser()
		{
			GetDataFromMemeory();
		}
	}
}
