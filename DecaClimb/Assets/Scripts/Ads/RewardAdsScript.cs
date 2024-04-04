using System;

using UnityEngine.Advertisements;

namespace DecaClimb.Ads
{
	/// <summary>
	/// Ads that cannot be skip and gives reward on completion
	/// </summary>
    public class RewardAdsScript : AdsController
    {
		public RewardAdsScript(string id) : base(id)
		{
		}

		public Action OnAdsShowCompleted { get; set; }
		public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
		{
			base.OnUnityAdsShowComplete(placementId, showCompletionState);
			if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
			{
				OnAdsShowCompleted();
				OnAdsShowCompleted = null;
			}
		}
	}
}
