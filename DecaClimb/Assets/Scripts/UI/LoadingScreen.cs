using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DecaClimb
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject m_LoadingPanel;
        [SerializeField] private Slider m_Slider;

		private void Awake()
		{
			m_LoadingPanel.SetActive(false);
		}

		public void StartLoadinScreen()
        {
            m_Slider.value = 0;
            m_LoadingPanel.SetActive(true);
        }

        public void UpdateSlider(float value)
        {
            m_Slider.value = value;
        }

        public void LoadingComplete()
        {
            m_LoadingPanel.SetActive(false);
        }
    }
}
