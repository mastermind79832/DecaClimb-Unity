using UnityEngine;

namespace Revity.DecaClimb.Game.UI
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GameOverUI m_GameOverUI;
        public GameOverUI GameOverUI { get { return m_GameOverUI; } }

		//[SerializeField] private ScoreUI m_ScoreDisplay;
		//[SerializeField] private LevelUI m_LevelDisplay;
		//[SerializeField] private CoinUI m_CoinDisplay;

		public void OnGameStart()
        {
            GameOverUI.OnGameStart();
        }

    }
}
