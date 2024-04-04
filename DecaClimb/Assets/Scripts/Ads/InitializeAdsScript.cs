using UnityEngine;
using UnityEngine.Advertisements;

namespace DecaClimb.Ads
{
	/// <summary>
	/// Script that intializes unity ads according to ID 
	/// Sets testing
	/// </summary>
    public class InitializeAdsScript : IUnityAdsInitializationListener
	{
		[SerializeField] private string m_AndroidGameId;
		[SerializeField] private bool m_IsTesting;

		public InitializeAdsScript(string id, bool isTesting)
		{
			m_AndroidGameId = id;
			m_IsTesting = isTesting;
			if (!Advertisement.isInitialized && Advertisement.isSupported)
			{
				Advertisement.Initialize(m_AndroidGameId, m_IsTesting, this);
			}
		}

		#region Callback
		public void OnInitializationComplete()
		{
			Debug.Log("<color=green> Success </color>");
		}

		public void OnInitializationFailed(UnityAdsInitializationError error, string message)
		{
			Debug.LogWarning("<color=yellow>" + message + "</color>");
		}

		#endregion
	}
}
