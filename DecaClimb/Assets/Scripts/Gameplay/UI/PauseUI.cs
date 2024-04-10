using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Revity.DecaClimb.Game.UI
{
    public class PauseUI : MonoBehaviour
    {
		[SerializeField] private GameObject m_PausePanel;
		[SerializeField] private Button m_YesButton;
		[SerializeField] private Button m_NoButton;

		public bool IsActive { get { return m_PausePanel.activeSelf; } }

		public void DisableUI()
		{
			m_PausePanel.SetActive(false);
		}

		/// <summary>
		/// Initilaze the Pause UI.
		/// </summary>
		/// <param name="onYesClick">for Yes button</param>
		/// <param name="onBackClick">for No button</param>
		public void Initialize(UnityAction onYesClick, UnityAction onBackClick)
		{
			m_YesButton.onClick.AddListener(onYesClick);
			m_NoButton.onClick.AddListener(onBackClick);
		}

		/// <summary>
		/// Display pause UI
		/// </summary>
		public void ShowPauseUI()
		{
			m_PausePanel.SetActive(true);
		}
	}
}
