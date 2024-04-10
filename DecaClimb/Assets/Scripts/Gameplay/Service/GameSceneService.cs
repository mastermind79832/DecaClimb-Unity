using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Revity.Core;
using System;
using Revity.DecaClimb.Game.UI;

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
			CreateService();
			// Start game
			// Check for tutorial
		}
		private void Start()
		{
			RefreshLevel();
		}
		private void CreateService()
		{
			m_FactoryService = new(m_FactorDataSO);
		}

		public void RefreshLevel()
		{
			FactoryService.Restart();
			PillarSpawn.transform.eulerAngles = Vector3.zero;
			PillarSpawn.Initialize();
			Player.ResetPosition();
			UIManager.OnGameStart();
		}

		// Reset everything

		// Start game
		// Pause game
		// Stop game


	}
}
