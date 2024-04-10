using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Revity.DecaClimb
{
    /// <summary>
    /// Controls the GmaeOver UI
    /// </summary>
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject GameOverPanel;
        [SerializeField] private Button m_YesButton;
        [SerializeField] private Image m_VideoButton;
        [SerializeField] private Button m_NoButton;
        [SerializeField] private TextMeshProUGUI m_HighscoreText;

        public bool IsActive { get { return GameOverPanel.activeSelf; } }

        public void OnGameStart()
        {
            GameOverPanel.SetActive(false);
        }

		/// <summary>
		/// Initilaze the Game UI.
		/// </summary>
		/// <param name="onYesClick">for Yes button</param>
		/// <param name="onBackClick">for No button</param>
		public void Initialize(UnityAction onYesClick, UnityAction onBackClick)
        {
            m_YesButton.onClick.AddListener(onYesClick);
            m_NoButton.onClick.AddListener(onBackClick);
        }

        /// <summary>
        /// Initialize Game over UI
        /// </summary>
        /// <param name="isRetryAvailable">Based on this retry button is interactable</param>
        /// <param name="highscore">To Displays highscore at the end</param>
        public void ShowGameOverUI(bool isRetryAvailable, int highscore)
        {
            GameOverPanel.SetActive(true);
            m_YesButton.interactable = isRetryAvailable;
            m_VideoButton.gameObject.SetActive(isRetryAvailable);
           
            // Set Highscore
            m_HighscoreText.text = $"Highscore: {highscore}";
            GameOverPanel.SetActive(isRetryAvailable);
        }
    }
}
