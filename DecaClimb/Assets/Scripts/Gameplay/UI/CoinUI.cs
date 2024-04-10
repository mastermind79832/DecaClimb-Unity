using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Revity.DecaClimb.Game.UI
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_CoinText;

        public void UpdateText(int coin)
        {
            m_CoinText.text = coin.ToString();
        }
    }
}
