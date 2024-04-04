using System;
using UnityEngine;

namespace DecaClimb.Ads
{
    /// <summary>
    /// Manages reference to all ads script
    /// </summary>
    public class AdsManager : MonoSingletonGeneric<AdsManager>
    {
        [SerializeField] private AdsDataSO m_AdsDataSO;

        private InitializeAdsScript m_InitializeAds;
        public InitializeAdsScript InitializeAds {  get { return m_InitializeAds; } }

		private InterstitialAdsScript m_InterstitialAds;
		public InterstitialAdsScript InterstitialAds { get { return m_InterstitialAds; } }

        private BannerAdsScript m_BannerAds;
        public BannerAdsScript BannerAds {  get { return m_BannerAds; } }

        private RewardAdsScript m_RewardAds;
        public RewardAdsScript RewardAds {  get { return m_RewardAds; } }

		protected override void Awake()
		{
			base.Awake();

			InitializeScripts();
			LoadAllAds();
		}

		private void InitializeScripts()
		{
			m_InitializeAds = new InitializeAdsScript(m_AdsDataSO.AndroidGameId, m_AdsDataSO.IsTesting);
            m_BannerAds = new BannerAdsScript(m_AdsDataSO.BannerAdsUnitId);
            m_InterstitialAds = new InterstitialAdsScript(m_AdsDataSO.InterstitalAdsUnitId);
            m_RewardAds = new RewardAdsScript(m_AdsDataSO.RewardAdsUnitId);
		}
		private void LoadAllAds()
		{
			BannerAds.LoadAd();
			InterstitialAds.LoadAd();
			RewardAds.LoadAd();
		}
	}
}
