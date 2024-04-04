using UnityEngine;
using UnityEngine.Advertisements;

namespace DecaClimb.Ads
{
	/// <summary>
	/// parent class of ads
	/// </summary>
	public abstract class AdsController : IUnityAdsLoadListener, IUnityAdsShowListener
	{
		[SerializeField] protected string m_AndroidUnitId;
		public bool IsAdsLoaded { get; private set; }

		public AdsController(string id)
		{
			m_AndroidUnitId = id;
			IsAdsLoaded = false;
		}

		public virtual void LoadAd()
		{
			Advertisement.Load(m_AndroidUnitId, this);
		}
		public virtual void ShowAd()
		{
			Advertisement.Show(m_AndroidUnitId, this);
			LoadAd();
		}


		#region CallBack Load
		public virtual void OnUnityAdsAdLoaded(string placementId)
		{
			IsAdsLoaded = true;
		}

		public virtual void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
		{
			IsAdsLoaded = false;
		}

		#endregion

		#region CallBack Show
		public virtual void OnUnityAdsShowClick(string placementId)
		{
			
		}

		public virtual void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
		{
			
		}

		public virtual void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
		{
			
		}

		public virtual void OnUnityAdsShowStart(string placementId)
		{
			
		}
		#endregion
	}
}
