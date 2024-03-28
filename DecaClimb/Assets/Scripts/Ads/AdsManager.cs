using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecaClimb.Ads
{
    public class AdsManager : MonoSingletonGeneric<AdsManager>
    {
        public InitializeAds initializeAds;
        public InterstitialAds interstitialAds;
        public BannerAds bannerAds;
        public RewardAds rewardAds;

        public bool DeactivateAds;

		protected override void Awake()
		{
			base.Awake();
            DontDestroyOnLoad(gameObject);

            if(DeactivateAds)
            {
                return;
            }

            bannerAds.LoadAd();
            interstitialAds.LoadAd();
            rewardAds.LoadAd();
		}


	}
}
