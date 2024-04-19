using System;
using UnityEngine;

namespace Revity.DecaClimb.Persistant
{
	public class CheckpointDataManager
	{
		private const string STR_CHECKPOINT = "Checkpoint";

		[SerializeField] private int m_Checkpoint;
		public int Checkpoint { get { return m_Checkpoint; } }

		public event Action<int> OnCheckpointChanged;

		public void SaveCheckpoint(int checkpoint)
		{
			PlayerPrefs.SetInt(STR_CHECKPOINT, checkpoint);
			m_Checkpoint = checkpoint;
			OnCheckpointChanged?.Invoke(checkpoint);
		}

		public void NewInstall()
		{
			SaveCheckpoint(0);
		}

		public void Initialize()
		{	
			m_Checkpoint = PlayerPrefs.GetInt(STR_CHECKPOINT, 0);
		}
	}
}
