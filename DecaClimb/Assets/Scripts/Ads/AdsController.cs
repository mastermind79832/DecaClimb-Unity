using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace DecaClimb.Ads
{
    public abstract class AdsController : MonoBehaviour, IUnityAdsLoadListener , IUnityAdsShowListener
	{
		[SerializeField] protected string androidUnitId;

		public virtual void LoadAd()
		{
			Advertisement.Load(androidUnitId, this);
		}
		public virtual void ShowAd()
		{
			Advertisement.Show(androidUnitId, this);
			LoadAd();
		}


		#region CallBack Load
		public virtual void OnUnityAdsAdLoaded(string placementId)
		{
			
		}

		public virtual void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
		{
			
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