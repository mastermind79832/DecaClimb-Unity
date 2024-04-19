

namespace Revity.DecaClimb.Persistant
{

	// For json
	struct SaveData
	{
		public float Version;
		public int Coin;
		public int Highscore;
		public int Checkpoint;
	}


	/// <summary>
	/// script that handles the all the data related funcitonality
	/// </summary>
    public class DataHandler 
    {
        private SettingsManager m_SettingsManager;
        public SettingsManager SettingsManager { get { return m_SettingsManager; } }	

		private CoinDataManager m_CoinDataManager;
		public CoinDataManager CoinData { get { return m_CoinDataManager; } }

		private HighscoreDataManager m_HighscoreDataManager;
		public HighscoreDataManager HighscoreData { get { return m_HighscoreDataManager; } }

		private CheckpointDataManager m_CheckpointDataManager;
		public CheckpointDataManager CheckpointData { get { return m_CheckpointDataManager; } }

		private BackgroundColorHandler m_BackgroundColorHandler;
		public BackgroundColorHandler BackgroundColor {  get { return m_BackgroundColorHandler; } }

		public DataHandler(BackgroundColorHandlerSO colorSO)
		{
			CreateService(colorSO);
			InitializeService();
		}
		private void CreateService(BackgroundColorHandlerSO colorSO)
		{
			m_SettingsManager = new SettingsManager();
			m_CoinDataManager = new CoinDataManager();
			m_HighscoreDataManager = new HighscoreDataManager();
			m_CheckpointDataManager = new CheckpointDataManager();
			m_BackgroundColorHandler = new BackgroundColorHandler(colorSO);
		}

		private void InitializeService()
		{
			if (SettingsManager.LoadState.Equals(LoadState.NewInstall))
			{
				CoinData.NewInstall();
				HighscoreData.NewInstall();
				CheckpointData.NewInstall();
			}
			else if (SettingsManager.LoadState.Equals(LoadState.Updated))
			{
				// Show change log
			}
			else 
			{ 
				// Welcome Back?
			}

			CoinData.Initialize();
			HighscoreData.Initialize();
			CheckpointData.Initialize();
		}

		//public class BlockSerialization
		//{
		//	public static string SerializeSaveData<T>(T data)
		//	{
		//		return JsonConvert.SerializeObject(data, Formatting.Indented);
		//	}

		//	public static T DeserializeSaveData<T>(string data)
		//	{
		//		return JsonConvert.DeserializeObject<T>(data);
		//	}
		//}
	}
}
