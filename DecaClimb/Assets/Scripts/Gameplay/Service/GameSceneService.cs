using UnityEngine;
using Revity.Core;
using Revity.DecaClimb.Game.UI;
using System;

namespace Revity.DecaClimb.Game
{
	/// <summary>
	/// Script that handles all the states of the game.
	/// </summary>
    public class GameSceneService : MonoSingletonGeneric<GameSceneService>
    {
		// Game Manager references
        [SerializeField] private GameManager m_GameManager;
		public GameManager GameManager { get { return m_GameManager; } }
		[SerializeField] private GameUIManager m_UIManager;
		public GameUIManager UIManager { get { return m_UIManager; } }

		private LevelManager m_LevelManager;
		public LevelManager LevelManager { get { return m_LevelManager; } }

		private ScoreManager m_ScoreManager;
		public ScoreManager ScoreManager { get { return m_ScoreManager; } }

		private CoinManager m_CoinManager;
		public CoinManager CoinManager { get { return m_CoinManager; } }

		// Factory References
		[SerializeField] private FactoryDataSO m_FactorDataSO;
		private FactoryService m_FactoryService;
		public FactoryService FactoryService {  get { return m_FactoryService; } }

		// Pillar Creator Reference
		[SerializeField] private PillarSpwan m_PillarSpawn;
		public PillarSpwan PillarSpawn { get {  return m_PillarSpawn; } }

		//Player Reference
		[SerializeField] private Player m_Player;
		public Player Player { get { return m_Player; } }


		// Initialize everything
		override protected void Awake()
		{
			base.Awake();
			InitializeService();
			SetEvents();
			// Start game
			// Check for tutorial
		}
		private void InitializeService()
		{
			UIManager.Initialize();
			m_FactoryService = new(m_FactorDataSO);
			m_LevelManager = new();
			m_ScoreManager = new();
			m_CoinManager = new();

			GameManager.Initialize();
		}

		private void SetEvents()
		{
			// UI update
			LevelManager.OnLevelChanged += UIManager.LevelUI.UpdateText;
			ScoreManager.OnScoreChanged += UIManager.ScoreUI.UpdateText;
			CoinManager.OnCoinChange += UIManager.CoinUI.UpdateText;
		}

		private void Start()
		{
			StartGame();
		}

		private void StartGame()
		{
			LevelManager.StartGame();
			ScoreManager.StartGame();
			CoinManager.StartGame();
			FactoryService.NewLevel();
			PillarSpawn.NewLevel();
			Player.ResetPosition();
			UIManager.DisableInterupt();
			//NextLevel();
		}
		private void Update()
		{
			ScoreManager.Update(Time.deltaTime);
		}

		public void NextLevel()
		{
			FactoryService.NewLevel();
			PillarSpawn.NewLevel();
			Player.ResetPosition();
			UIManager.DisableInterupt();
		}

		// Reset everything

		// Start game
		// Pause game
		// Stop game


	}
}
