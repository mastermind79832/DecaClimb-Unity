using UnityEngine;

namespace DecaClimb.Ads
{
    [CreateAssetMenu(fileName = "AdsDataSO", menuName = "DataSO/Ads")]
    public class AdsDataSO : ScriptableObject
    {
		[Header("Android Data")]
		public string AndroidGameId;
		public bool IsTesting;

		[Header("Ads Data")]
		public string BannerAdsUnitId;
		public string InterstitalAdsUnitId;
		public string RewardAdsUnitId;

	}
}
