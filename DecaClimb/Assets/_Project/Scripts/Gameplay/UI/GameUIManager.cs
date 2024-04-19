using UnityEngine;

namespace Revity.DecaClimb.Game.UI
{
    public class GameUIManager : MonoBehaviour
    {
		[Header("Interrupt UI")]
        [SerializeField] private GameOverUI m_GameOverUI;
        public GameOverUI GameOverUI { get { return m_GameOverUI; } }

		[SerializeField] private PauseUI m_PauseUI;
        public PauseUI PauseUI { get { return m_PauseUI; } }

		[Header("Data Display UI")]
		[SerializeField] private ScoreUi m_ScoreUI;
        public ScoreUi ScoreUI { get { return m_ScoreUI; } }

		[SerializeField] private LevelUI m_LevelUI;
        public LevelUI LevelUI { get { return m_LevelUI; } }
        
        [SerializeField] private CoinUI m_CoinUI;
        public CoinUI CoinUI { get { return m_CoinUI; } }

		public void Initialize()
        {

        }
		public void DisableInterupt()
		{
			GameOverUI.DisableUI();
			PauseUI.DisableUI();
		}

	}
}
