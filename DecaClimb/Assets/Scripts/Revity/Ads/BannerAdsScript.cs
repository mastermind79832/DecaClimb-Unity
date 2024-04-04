using UnityEngine.Advertisements;

namespace Revity.Ads
{
	/// <summary>
	/// For banner ads
	/// </summary>
    public class BannerAdsScript : AdsController
    {
		public BannerAdsScript(string id, BannerPosition bannerPosition) : base(id)
		{
			Advertisement.Banner.SetPosition(bannerPosition);
		}

		public override void LoadAd()
		{
			BannerLoadOptions options = new BannerLoadOptions()
			{
				loadCallback = BannerLoaded,
				errorCallback = BannerLoadedError
			};

			Advertisement.Banner.Load(m_DeviceUnitId, options);
		}

		public override void ShowAd()
		{
			BannerOptions options = new BannerOptions()
			{
				showCallback = BannerShown,
				clickCallback = BannerClicked,
				hideCallback = BannerHidden
			};

			Advertisement.Banner.Show(m_DeviceUnitId, options);
		}

		public void HideBannerAd()
		{
			Advertisement.Banner.Hide();
		}

		#region Callback Show
		private void BannerHidden()
		{
			
		}

		private void BannerClicked()
		{
			
		}

		private void BannerShown()
		{
			
		}
		#endregion

		#region CallBack Load
		private void BannerLoadedError(string message)
		{	
		}

		private void BannerLoaded()
		{
		}
		#endregion
	}
}
