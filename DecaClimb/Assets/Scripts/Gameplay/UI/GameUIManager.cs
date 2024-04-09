using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb.Game.UI
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GameOverUI m_GameOverUI;
        public GameOverUI GameOverUI { get { return m_GameOverUI; } }

        public void OnGameOver(bool isRetryPossible, int highScore)
        {
            m_GameOverUI.ShowGameOverUI(isRetryPossible, highScore);
        }
    }
}
