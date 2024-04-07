using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

        public void Initialize()
        {
            m_YesButton.onClick.AddListener(null);
            m_NoButton.onClick.AddListener(null);
        }

        /// <summary>
        /// Initialize Game over UI
        /// </summary>
        /// <param name="isRetryAvailable">Based on this retry button is interactable</param>
        /// <param name="highscore">To Displays highscore at the end</param>
        public void ShowGameOverUI(bool isRetryAvailable, int highscore)
        {
            m_YesButton.interactable = isRetryAvailable;
            m_VideoButton.gameObject.SetActive(isRetryAvailable);
            // Set Highscore

            m_HighscoreText.text = $"Highscore: {highscore}";
            GameOverPanel.SetActive(isRetryAvailable);
        }
    }
}
