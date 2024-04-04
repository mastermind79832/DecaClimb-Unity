using UnityEngine;
using UnityEngine.Advertisements;

namespace Revity.Ads
{
    [CreateAssetMenu(fileName = "AdsDataSO", menuName = "DataSO/Ads")]
    public class AdsDataSO : ScriptableObject
    {
		[Header("Android Data")]
		public string DeviceGameId;
		public bool IsTesting;

		[Header("Ads Data")]
		public string BannerAdsUnitId;
		public BannerPosition BannerPosition;
		public string InterstitalAdsUnitId;
		public string RewardAdsUnitId;

	}
}
