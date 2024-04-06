using Revity.DecaClimb.Persistant;
using UnityEngine;
using UnityEngine.UI;

namespace Revity.DecaClimb.MainMenu
{
    /// <summary>
    /// Manages the UI of mainmenu
    /// </summary>
    public class MainMenuUIManager : MonoBehaviour
    {
        [SerializeField] private Text m_HighScoreText;
        [SerializeField] private Text m_CheckPointText;
        [SerializeField] private Text m_CoinText;

        [SerializeField] private GameObject m_InstructionPanel;
        [SerializeField] private GameObject m_CheatPanel;

        [SerializeField] private InputField m_CoinsCheat;
        [SerializeField] private InputField m_LevelCheat;

        [SerializeField] private Button m_PlayButton;
        [SerializeField] private Button m_UpgradeButton;

		private void Awake()
        {
            m_CheatPanel.SetActive(false);
            m_InstructionPanel.SetActive(false);
           
        }

		private void Start()
		{
            m_HighScoreText.text = PersistantServiceLocator.Instance.DataHandler.HighscoreData.HighScore.ToString();
            m_CheckPointText.text = PersistantServiceLocator.Instance.DataHandler.CheckpointData.Checkpoint.ToString();
            m_CoinText.text = PersistantServiceLocator.Instance.DataHandler.CoinData.Coins.ToString();

            m_PlayButton.onClick.AddListener(MainMenuService.Instance.GameStart);
            m_UpgradeButton.onClick.AddListener(MainMenuService.Instance.OpenUpgrade);			
		}

		public void UpgradePage()
        {
			PersistantServiceLocator.Instance.SceneService.LoadUpgradeScene();        
        }

        #region Cheat
        public void Cheats()
        {
            if (m_CheatPanel.activeSelf)
                m_CheatPanel.SetActive(false);
            else
                m_CheatPanel.SetActive(true);
        }

        public void SetCheat()
        {
            // int coin = int.Parse(coinsCheat.text);
            // int level =  int.Parse(levelCheat.text);

            if (m_CoinsCheat.text != "")
            {
                int coin = System.Convert.ToInt32(m_CoinsCheat.text);
				PersistantServiceLocator.Instance.DataHandler.CoinData.SaveCoins(coin);
                m_CoinText.text = PersistantServiceLocator.Instance.DataHandler.CoinData.Coins.ToString();
            }


            if (m_LevelCheat.text != "")
            {
                int level = System.Convert.ToInt32(m_LevelCheat.text);
				PersistantServiceLocator.Instance.DataHandler.CheckpointData.SaveCheckpoint(level);
                m_CheckPointText.text = PersistantServiceLocator.Instance.DataHandler.CheckpointData.Checkpoint.ToString();
			}
        }
        #endregion

    }
}