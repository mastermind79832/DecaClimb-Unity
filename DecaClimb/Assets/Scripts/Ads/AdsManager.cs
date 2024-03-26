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

		protected override void Awake()
		{
			base.Awake();
            DontDestroyOnLoad(gameObject);

            bannerAds.LoadAd();
            interstitialAds.LoadAd();
            rewardAds.LoadAd();
		}


	}
}
