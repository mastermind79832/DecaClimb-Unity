using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Revity.Core;
using System;

namespace Revity.DecaClimb.Game
{
	/// <summary>
	/// Script that handles all the states of the game.
	/// </summary>
    public class GameSceneService : MonoSingletonGeneric<GameSceneService>
    {
        [SerializeField] private GameManager m_GameManager;
		public GameManager GameManager { get { return m_GameManager; } }

		[SerializeField] private FactoryDataSO m_FactorDataSO;
		private FactoryService m_FactoryService;
		public FactoryService FactoryService {  get { return m_FactoryService; } }


		// Initialize everything
		override protected void Awake()
		{
			base.Awake();
			CreateService();
			// Start game
			// Check for tutorial
		}

		private void CreateService()
		{
			m_FactoryService = new(m_FactorDataSO);
		}

		// Reset everything

		// Start game
		// Pause game
		// Stop game


	}
}
