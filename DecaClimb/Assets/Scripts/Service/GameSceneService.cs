using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Revity.Core;

namespace Revity.DecaClimb
{
	/// <summary>
	/// Script that handles all the states of the game.
	/// </summary>
    public class GameSceneService : MonoSingletonGeneric<GameSceneService>
    {
        [SerializeField] private GameManager m_GameManager;
		public GameManager GameManager { get { return m_GameManager; } }
		
		[SerializeField] private FactoryService m_FactoryService;
		public FactoryService FactoryService {  get { return m_FactoryService; } }


		// Initialize everything
		private void Awake()
		{
			// Start game
			// Check for tutorial
		}

		// Reset everything

		// Start game
		// Pause game
		// Stop game

		
	}
}
