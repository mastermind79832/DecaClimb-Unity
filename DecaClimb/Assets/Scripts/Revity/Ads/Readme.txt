Unity Ads Manager script [Created by aditya]
-------------------------------------
Setup:
-	Attach AdsManager.cs into any Gameobject in the scene
-	Create a scriptable object on AdsDataSO: Right Click -> DataSO -> Ads.
-	Fill the data in it.
 	Device Game Id is where you put the android or ios game id.
	Make sure to keep IsTesting true for the entire development as well as testing, Only make it false for release build.
--------------------------------------
Use:
-	Add Header using Revity.Ads
-	Function Call Example to show ads : AdsManager.Instance.InterstitialAds.ShowAd();
---------------------------------------
Special Case: 
-	For Rewards Ad, 
	Subscribe to this event that gets called after the Ads has been completed:
	AdsManager.Instance.RewardAds.OnAdsShowCompleted = <function to be called to set rewards>;
	AdsManager.Instance.RewardAds.ShowAd();