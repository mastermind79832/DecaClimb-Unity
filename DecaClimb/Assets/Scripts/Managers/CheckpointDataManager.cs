using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb.Persistant
{
	public class CheckpointDataManager
	{
		private const string STR_CHECKPOINT = "CheckPoint";

		[SerializeField] private int m_CheckPoint;
		public int Checkpoint { get { return m_CheckPoint; } }

		public event Action<int> OnCheckpointChanged;

		public void SaveCheckPoint(int checkPoint)
		{
			PlayerPrefs.SetInt(STR_CHECKPOINT, checkPoint);
			m_CheckPoint = checkPoint;
			OnCheckpointChanged?.Invoke(checkPoint);
		}

		public void NewInstall()
		{
			SaveCheckPoint(0);
		}

		public void Initialize()
		{	
			m_CheckPoint = PlayerPrefs.GetInt(STR_CHECKPOINT);
		}
	}
}
