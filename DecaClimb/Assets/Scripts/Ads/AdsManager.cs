using UnityEngine;

namespace DecaClimb.Ads
{
    /// <summary>
    /// Manages reference to all ads script
    /// </summary>
    public class AdsManager : MonoSingletonGeneric<AdsManager>
    {
        [SerializeField] private InitializeAdsScript m_InitializeAds;
        public InitializeAdsScript InitializeAds {  get { return m_InitializeAds; } }

		[SerializeField]
		private InterstitialAdsScript m_InterstitialAds;
		public InterstitialAdsScript InterstitialAds { get { return m_InterstitialAds; } }

        [SerializeField]
        private BannerAdsScript m_BannerAds;
        public BannerAdsScript BannerAds {  get { return m_BannerAds; } }

        [SerializeField]
        private RewardAdsScript m_RewardAds;
        public RewardAdsScript RewardAds {  get { return m_RewardAds; } }

		protected override void Awake()
		{
			base.Awake();
            DontDestroyOnLoad(gameObject);

            BannerAds.LoadAd();
            InterstitialAds.LoadAd();
            RewardAds.LoadAd();
		}


	}
}
