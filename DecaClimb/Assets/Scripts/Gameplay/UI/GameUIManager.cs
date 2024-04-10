using UnityEngine;

namespace Revity.DecaClimb.Game.UI
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GameOverUI m_GameOverUI;
        public GameOverUI GameOverUI { get { return m_GameOverUI; } }

		[SerializeField] private ScoreUi m_ScoreUI;
        public ScoreUi ScoreUI { get { return m_ScoreUI; } }

		[SerializeField] private LevelUI m_LevelUI;
        public LevelUI LevelUI { get { return m_LevelUI; } }

		[SerializeField] private PauseUI m_PauseUI;
        public PauseUI PauseUI { get { return m_PauseUI; } }
        
        [SerializeField] private CoinUI m_CoinUI;
        public CoinUI CoinUI { get { return m_CoinUI; } }

		//[SerializeField] private ScoreUI m_ScoreDisplay;
		//[SerializeField] private LevelUI m_LevelDisplay;
		//[SerializeField] private CoinUI m_CoinDisplay;

		public void Initialize()
        {

        }
		public void StartGame()
		{
			GameOverUI.DisableUI();
			PauseUI.DisableUI();
		}

	}
}
