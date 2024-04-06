using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb.Persistant
{
	public class HighscoreDataManager
	{
		private const string STR_HIGHSCORE = "Highscore";

		[SerializeField] private int m_HighScore;
		public int HighScore { get { return m_HighScore; } }
		public event Action<int> OnHighScoreChanged;

		public void SaveHighscore(int highscore)
		{
			PlayerPrefs.SetInt(STR_HIGHSCORE, highscore);
			m_HighScore = highscore;
			OnHighScoreChanged?.Invoke(HighScore); // achievement/prompt
		}

		public void NewInstall()
		{
			SaveHighscore(0);
		}
		public void Initialize()
		{		
			m_HighScore = PlayerPrefs.GetInt(STR_HIGHSCORE);
		}


	}
}
