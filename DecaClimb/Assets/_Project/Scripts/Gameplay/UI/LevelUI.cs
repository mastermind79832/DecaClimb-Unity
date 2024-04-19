using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Revity.DecaClimb.Game.UI
{
    public class LevelUI : MonoBehaviour
    {
		[SerializeField] private TextMeshProUGUI m_LevelText;

		public void UpdateText(int coin)
		{
			m_LevelText.text = coin.ToString();
		}
	}
}
