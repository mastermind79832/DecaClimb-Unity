using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace DecaClimb.Ads
{
    public class BannerAds : AdsController
    {
		private void Awake()
		{
			if (AdsManager.Instance.DeactivateAds)
			{
				return;
			}
			Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
		}

		public override void LoadAd()
		{
			if (AdsManager.Instance.DeactivateAds)
			{
				return;
			}
			BannerLoadOptions options = new BannerLoadOptions()
			{
				loadCallback = BannerLoaded,
				errorCallback = BannerLoadedError
			};

			Advertisement.Banner.Load(androidUnitId, options);
		}

		public override void ShowAd()
		{
			if (AdsManager.Instance.DeactivateAds)
			{
				return;
			}
			BannerOptions options = new BannerOptions()
			{
				showCallback = BannerShown,
				clickCallback = BannerClicked,
				hideCallback = BannerHidden
			};

			Advertisement.Banner.Show(androidUnitId, options);
		}

		public void HideBannerAd()
		{
			if (AdsManager.Instance.DeactivateAds)
			{
				return;
			}
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
