using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace DecaClimb.Ads
{
    public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
	{
		[SerializeField] private string m_AndroidGameId;
		[SerializeField] private bool isTesting;

		private void Awake()
		{
			if (!Advertisement.isInitialized && Advertisement.isSupported)
			{
				Advertisement.Initialize(m_AndroidGameId, isTesting, this);
			}
		}

		#region Callback
		public void OnInitializationComplete()
		{
			Debug.Log("<color = green> Success </color>");
		}

		public void OnInitializationFailed(UnityAdsInitializationError error, string message)
		{
			Debug.LogWarning("<color = yellow>" + message + "</color>");
		}

		#endregion
	}
}
