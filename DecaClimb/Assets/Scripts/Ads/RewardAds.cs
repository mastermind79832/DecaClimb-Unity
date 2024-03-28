using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace DecaClimb.Ads
{
    public class RewardAds : AdsController
    {
		public override void ShowAd()
		{
			if (AdsManager.Instance.DeactivateAds)
			{
				GameManager.Instance.IsRewarded = true;
				GameManager.Instance.GetRetryReward();
			}
			base.ShowAd();
		}

		public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
		{
			base.OnUnityAdsShowComplete(placementId, showCompletionState);
			if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
			{
				GameManager.Instance.IsRewarded = true;
				GameManager.Instance.GetRetryReward();
			}
		}
	}
}
