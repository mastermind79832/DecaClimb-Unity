using UnityEngine;
using UnityEngine.UI;

namespace DecaClimb
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
           
            m_HighScoreText.text = PersistantDataHandler.Instance.ProgressManager.HighScore.ToString();
            m_CheckPointText.text = PersistantDataHandler.Instance.ProgressManager.Checkpoint.ToString();
            m_CoinText.text = PersistantDataHandler.Instance.EconomyManager.Coins.ToString();

            m_PlayButton.onClick.AddListener(MainMenuService.Instance.GameStart);
            m_UpgradeButton.onClick.AddListener(MainMenuService.Instance.OpenUpgrade);
        }

        public void UpgradePage()
        {
            PersistantSceneService.Instance.LoadUpgradeScene();        
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
				PersistantDataHandler.Instance.EconomyManager.SetCoins(coin);
                m_CoinText.text = PersistantDataHandler.Instance.EconomyManager.Coins.ToString();
            }


            if (m_LevelCheat.text != "")
            {
                int level = System.Convert.ToInt32(m_LevelCheat.text);
				PersistantDataHandler.Instance.ProgressManager.SetCheckPoint(level);
                m_CheckPointText.text = PersistantDataHandler.Instance.ProgressManager.Checkpoint.ToString();
			}
        }
        #endregion

    }
}