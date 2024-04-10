using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Revity.DecaClimb.Game.UI
{
    public class ScoreUi : MonoBehaviour
    {
		[SerializeField] private TextMeshProUGUI m_ScoreText;

		public void UpdateText(int coin)
		{
			m_ScoreText.text = coin.ToString();
		}
	}
}
